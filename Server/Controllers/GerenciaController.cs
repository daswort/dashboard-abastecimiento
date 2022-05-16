using Microsoft.AspNetCore.Mvc;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/gerencia")]
    [ApiController]
    public class GerenciaController : ControllerBase
    {
        private readonly CerberusMinutaContext _cerberusMinutaContext;

        public GerenciaController(CerberusMinutaContext cerberusMinutaContext)
        {
            _cerberusMinutaContext = cerberusMinutaContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetGerenciasPorDivision()
        {
            string division = Request.Query["division"];

            List<string> noGop = new() { "44444444-4","88888888-8", "11111111-1", "15208375-0" };
            List<string> divs = new() { "TRANSPORTADO", "TRADICIONAL" };

            var qr = (from t1 in _cerberusMinutaContext.Set<VtJopGopAx>()
                            where t1.CodGop != "CASINOS CERRADOS"
                            && !noGop.Contains(t1.CodGop)
                            select new Gerencia()
                            {
                                Rut = t1.CodGop,
                                Nombre = t1.Gop,
                                Division = t1.Area
                            });

            if (division != String.Empty)
                qr = qr.Where(x => x.Division == division);
            else
                qr = qr.Where(x => divs.Contains(x.Division));

            return Ok(await qr.Distinct().AsNoTracking().ToListAsync());
        }
    }
}
