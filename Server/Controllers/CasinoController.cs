using Microsoft.AspNetCore.Mvc;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/centro-costo")]
    [ApiController]
    public class CasinoController : ControllerBase
    {
        private readonly CerberusMinutaContext _cerberusMinutaContext;
        private readonly List<string> _areasPermitidas = new() { "TRADICIONAL", "TRANSPORTADO" };

        public CasinoController(CerberusMinutaContext cerberusMinutaContext)
        {
            _cerberusMinutaContext = cerberusMinutaContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CentroCosto>>> GetCentrosCosto()
        {
            var centrosCosto = (from t1 in _cerberusMinutaContext.Set<VtJopGopAx>()
                                   where t1.CodGop != "CASINOS CERRADOS"
                                   && _areasPermitidas.Contains(t1.Area)
                                   orderby t1.Name ascending
                                   select new CentroCosto()
                                   {
                                       Codigo = t1.Cc,
                                       Nombre = $"[{t1.Cc}] {t1.Name}",
                                       CodigoGerencia = t1.CodGop,
                                       CodigoJefatura = t1.CodJop
                                   });

            return Ok(await centrosCosto.AsNoTracking().ToListAsync());
        }

        [HttpGet("{jerarquia}")]
        public async Task<ActionResult<List<CentroCosto>>> GetCentrosCostoPorCodigoJerarquia(string jerarquia)
        {
            string codigo = Request.Query["codigo"];

            var centrosCosto = (from t1 in _cerberusMinutaContext.Set<VtJopGopAx>()
                                where t1.CodGop != "CASINOS CERRADOS"
                                && _areasPermitidas.Contains(t1.Area)
                                orderby t1.Name ascending
                                select new CentroCosto() 
                                { 
                                    Codigo = t1.Cc,
                                    Nombre = $"[{t1.Cc}] {t1.Name}",
                                    CodigoGerencia = t1.CodGop,
                                    CodigoJefatura = t1.CodJop,
                                });

            if (!string.IsNullOrEmpty(codigo))
            {
                if (jerarquia == "gerencia")
                    centrosCosto = centrosCosto.Where(x => x.CodigoGerencia == codigo);
                if (jerarquia == "jefatura")
                    centrosCosto = centrosCosto.Where(x => x.CodigoJefatura == codigo);
            }

            return Ok(await centrosCosto.AsNoTracking().ToListAsync());
        }
    }
}