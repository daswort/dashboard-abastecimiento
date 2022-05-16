using Microsoft.AspNetCore.Mvc;
using DashboardAbast.Server.Misc;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumenCasinoController : ControllerBase
    {
        private readonly PptoCeContext _pptoCeContext;
        private readonly CerberusMinutaContext _cerberusMinutaContext;
        private readonly AxCasinoContext _axCasinoContext;
        private readonly CerberusContext _cerberusContext;

        public ICentroCostoRepository Ent3 { get; private set; }

        public ResumenCasinoController(
            PptoCeContext pptoCeContext,
            CerberusMinutaContext cerberusMinutaContext,
            AxCasinoContext axCasinoContext,
            CerberusContext cerberusContext
        )
        {
            _pptoCeContext = pptoCeContext;
            _cerberusMinutaContext = cerberusMinutaContext;
            _axCasinoContext = axCasinoContext;
            _cerberusContext = cerberusContext;

            Ent3 = new CentroCostoRepository(_cerberusMinutaContext);
        }

        [HttpGet]
        public async Task<ActionResult> GetResumenCasino()
        {
            DateTime vFechaIni = Util.ProcessQsFecha(Request.Query["fecha-ini"]);
            DateTime vFechaFin = Util.ProcessQsFecha(Request.Query["fecha-fin"]);

            // Se obtiene la lista de OCs que los proveedores despacharan cuya fecha de entrega esté en rango de fechas dado
            var qr1 = await (from t1 in _pptoCeContext.Set<TblIconstruyeOcPaso>()
                             where t1.EstadoLinea != "OC Línea Cancelada" && t1.EstadoLinea != "OC Línea Rechazada" && t1.Fechaentrega >= vFechaIni && t1.Fechaentrega <= vFechaFin
                             select new { t1.NumOc }).Distinct().AsNoTracking().ToListAsync();

            // Se obtiene la lista de OCs creadas por CE cuya fecha de entrega esté en rango de fechas dado
            var qr2 = await (from t1 in _axCasinoContext.Set<Purchtable>()
                             where t1.Deliverydate >= vFechaIni && t1.Deliverydate <= vFechaFin && t1.Dataareaid == "cas"
                             orderby t1.Deliverydate descending
                             select new
                             {
                                 CodigoCasino = t1.Inventlocationid,
                                 NumOC = t1.Purchid,
                                 FechaEntregaAcordada = t1.Deliverydate.AddDays(1).AddSeconds(-1) // Se cambia la hora para que sea '{fecha} 23:59:59'
                             }).AsNoTracking().ToListAsync();

            // Se obtiene la lista de las OCs que se han recepcionado en el rango de fechas
            DateTime fechaActual = DateTime.Today.AddDays(1).AddSeconds(-1);
            DateTime fechaUnMesAtras = DateTime.Today.AddMonths(-1);

            var qr3 = await (from t1 in _cerberusContext.Set<RecepcionFolio>()
                             where t1.HoraRecepcion >= fechaUnMesAtras && t1.HoraRecepcion <= fechaActual && t1.IdEstadoRecepcion != 2
                             select new RecepcionFolioSet
                             {
                                 NumOc = t1.NumeroOrdenCompra,
                                 FechaEntregaReal = t1.HoraRecepcion
                             }).AsNoTracking().ToListAsync();

            // Se obtiene la lista de real de OC que serán despachadas
            var qr4 = (from t1 in qr2
                       join t2 in qr1 on t1.NumOC equals t2.NumOc
                       select new
                       {
                           t1.CodigoCasino,
                           t1.NumOC,
                           t1.FechaEntregaAcordada
                       });

            CentroCostoParametros centroCostoParametros = new CentroCostoParametros();
            centroCostoParametros.ListaId = qr4.Select(x => x.CodigoCasino).Distinct().ToList();
            var casinosList = await Ent3.ObtenerCentroCostos(centroCostoParametros).AsNoTracking().ToListAsync();

            // Se obtiene lista de OC que han sido despachadas y las que no aun con sus respectivas fechas
            var qr5 = (from t1 in qr4
                       join t2 in qr3 on t1.NumOC equals t2.NumOc into final
                       from aFinal in final.DefaultIfEmpty(new RecepcionFolioSet())
                       join t3 in casinosList on t1.CodigoCasino equals t3.Codigo
                       select new
                       {
                           CodigoCasino = t1.CodigoCasino,
                           NombreCasino = t3.Nombre,
                           //NumOc = t1.NumOC,
                           //FechaEntregaReal = aFinal.FechaEntregaReal,
                           //FechaEntregaAcordada = t1.FechaEntregaAcordada,
                           LlegoATiempo = (aFinal.FechaEntregaReal == null) ? false : ((aFinal.FechaEntregaReal > t1.FechaEntregaAcordada) ? false : true),
                       }).ToList();

            var qr6 = qr5
                .GroupBy(g => new { g.CodigoCasino, g.NombreCasino })
                .Select(g => new
                {
                    Codigo = g.Key.CodigoCasino,
                    Nombre = g.Key.NombreCasino,
                    Total = g.Count(),
                    Atiempo = g.Count(x => x.LlegoATiempo == true),
                    Atrasada = g.Count(x => x.LlegoATiempo == false),
                    PorcAtiempo = g.Any() ? (int)Math.Round((decimal)g.Count(x => x.LlegoATiempo == true) / g.Count() * 100) : 0,
                    PorcAtrasada = g.Any() ? (int)Math.Round((decimal)g.Count(x => x.LlegoATiempo == false) / g.Count() * 100) : 0
                });

            return Ok(qr6);
        }
    }
}