using Microsoft.AspNetCore.Mvc;
using DashboardAbast.Server.Misc;
using System.Text.Json;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/resumen-ejecutivo")]
    [ApiController]
    public class ResumenEjecutivoController : ControllerBase
    {
        private readonly PptoCeContext _pptoCeContext;
        private readonly AxCasinoContext _axCasinoContext;
        private readonly CerberusContext _cerberusContext;

        public IEjecutivoRepository EjecutivoRepo { get; private set; }

        public ResumenEjecutivoController(PptoCeContext pptoCeContext, AxCasinoContext axCasinoContext, CerberusContext cerberusContext)
        {
            _pptoCeContext = pptoCeContext;
            _axCasinoContext = axCasinoContext;
            _cerberusContext = cerberusContext;
            EjecutivoRepo = new EjecutivoRepository(_pptoCeContext);
        }

        [HttpGet]
        public async Task<ActionResult> GetResumenEjecutivo()
        {
            DateTime vFechaIni = Util.ProcessQsFecha(Request.Query["fecha-ini"]);
            DateTime vFechaFin = Util.ProcessQsFecha(Request.Query["fecha-fin"]);
            List<string> vCentroCosto = Util.ProcessQsCasino(Request.Query["centro-costo"]);
            List<string> vProveedor = Util.ProcessQsProveedor(Request.Query["proveedor"]);
            List<string> vFamilia = Util.ProcessQsFamilia(Request.Query["familia"]);
            List<string> vEjecutivo = Util.ProcessQsEjecutivo(Request.Query["ejecutivo"]);

            var casinosEjecutivoList = await (from t1 in _pptoCeContext.Set<TblEcRecurso>()
                                             join t2 in _pptoCeContext.Set<TblEcRecursoCentroCosto>() on t1.IdRecurso equals t2.IdRecurso
                                             where t1.IdArea == 5
                                             select new EjecutivoCasinoSet
                                             {
                                                 Rut = t1.Rut,
                                                 Nombre = t1.Nombre,
                                                 CentroCosto = t2.CentroCosto
                                             }).Distinct().AsNoTracking().ToListAsync();

            // Se obtiene la lista de OCs que los proveedores despacharan cuya fecha de entrega esté en rango de fechas dado
            var qr1 = await (from t1 in _pptoCeContext.Set<TblIconstruyeOcPaso>()
                             where t1.EstadoLinea != "OC Línea Cancelada" 
                             && t1.EstadoLinea != "OC Línea Rechazada" 
                             && t1.Fechaentrega >= vFechaIni 
                             && t1.Fechaentrega <= vFechaFin
                             select new { t1.NumOc }).Distinct().AsNoTracking().ToListAsync();

            // Se obtiene la lista de OCs creadas por CE cuya fecha de entrega esté en rango de fechas dado
            var qr2 = (from t1 in _axCasinoContext.Set<Purchtable>()
                       where t1.Deliverydate >= vFechaIni && t1.Deliverydate <= vFechaFin && t1.Dataareaid == "cas"
                       orderby t1.Deliverydate descending
                       select new
                       {
                           CodigoCasino = t1.Inventlocationid,
                           CodigoProveedor = t1.Invoiceaccount,
                           CodigoFamilia = t1.CosIdfamilia,
                           NumOC = t1.Purchid,
                           FechaEntregaAcordada = t1.Deliverydate.AddDays(1).AddSeconds(-1) // Se cambia la hora para que sea '{fecha} 23:59:59'
                       });
            if (vCentroCosto.Any())
                qr2 = qr2.Where(x => vCentroCosto.Contains(x.CodigoCasino));
            if (vProveedor.Any())
                qr2 = qr2.Where(x => vProveedor.Contains(x.CodigoProveedor));
            if (vFamilia.Any())
                qr2 = qr2.Where(x => vFamilia.Contains(x.CodigoFamilia));
            if (vEjecutivo.Any())
            {
                EjecutivoParametros ejecutivoParametros = new();
                ejecutivoParametros.ListaRut = vEjecutivo;
                var centrosCostoEjecutivos = await EjecutivoRepo.ObtenerListaCentroCosto(ejecutivoParametros).AsNoTracking().ToListAsync();
                qr2 = qr2.Where(x => centrosCostoEjecutivos.Contains(x.CodigoCasino));
            }
            var resQr2 = await qr2.AsNoTracking().ToListAsync();

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
            var qr4 = (from t1 in resQr2
                       join t2 in qr1 on t1.NumOC equals t2.NumOc
                       join t3 in casinosEjecutivoList on t1.CodigoCasino equals t3.CentroCosto into final from aFinal in final.DefaultIfEmpty(new EjecutivoCasinoSet())
                       select new
                       {
                           CodigoEjecutivo = aFinal.Rut,
                           NombreEjecutivo = aFinal.Nombre,
                           t1.NumOC,
                           t1.FechaEntregaAcordada
                       });

            // Se obtiene lista de OC que han sido despachadas y las que no aun con sus respectivas fechas
            var qr5 = (from t1 in qr4
                       join t2 in qr3 on t1.NumOC equals t2.NumOc into final from aFinal in final.DefaultIfEmpty(new RecepcionFolioSet())
                       select new
                       {
                           t1.CodigoEjecutivo,
                           t1.NombreEjecutivo,
                           NumOc = t1.NumOC,
                           FechaEntregaReal = aFinal.FechaEntregaReal,
                           FechaEntregaAcordada = t1.FechaEntregaAcordada,
                           SinRegistro = (aFinal.FechaEntregaReal == null) ? true : false,
                           LlegoATiempo = (bool?) ((aFinal.FechaEntregaReal == null) ? null : ((aFinal.FechaEntregaReal > t1.FechaEntregaAcordada) ? false : true)),
                       }).ToList();

            //System.Diagnostics.Debug.WriteLine("################ qr5: " + JsonSerializer.Serialize(qr5, new JsonSerializerOptions() { WriteIndented = true }));

            var qr6 = qr5
                .GroupBy(g => new { g.CodigoEjecutivo, g.NombreEjecutivo })
                .Select(g => new
                {
                    Codigo = g.Key.CodigoEjecutivo,
                    Nombre = (g.Key.NombreEjecutivo == null) ? "* Casinos no asignados" : g.Key.NombreEjecutivo,
                    Total = g.Count(),
                    SinRegistro = g.Count(x => x.LlegoATiempo == null),
                    Atiempo = g.Count(x => x.LlegoATiempo == true),
                    Atrasada = g.Count(x => x.LlegoATiempo == false),
                    PorcSinRegistro = g.Any() ? (int)Math.Round((decimal)g.Count(x => x.LlegoATiempo == null) / g.Count() * 100) : 0,
                    PorcAtiempo = g.Any() ? (int)Math.Round((decimal)g.Count(x => x.LlegoATiempo == true) / g.Count() * 100) : 0,
                    PorcAtrasada = g.Any() ? (int)Math.Round((decimal)g.Count(x => x.LlegoATiempo == false) / g.Count() * 100) : 0
                });

            return Ok(qr6);
        }
    } 
}
