using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/jefatura")]
    [ApiController]
    public class JefaturaController : ControllerBase
    {
        private readonly CerberusMinutaContext _cerberusMinutaContext;

        public JefaturaController(CerberusMinutaContext cerberusMinutaContext)
        {
            _cerberusMinutaContext = cerberusMinutaContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetJefaturasPorGerencia()
        {
            string gerencia = Request.Query["gerencia"];
            List<string> noGop = new() { "44444444-4", "88888888-8", "11111111-1", "15208375-0" };

            var qr = (from t1 in _cerberusMinutaContext.Set<VtJopGopAx>()
                      where t1.CodGop != "CASINOS CERRADOS"
                      && !noGop.Contains(t1.CodGop)
                      select new Jefatura()
                      {
                          Rut = t1.CodJop,
                          Nombre = t1.Jop,
                          Gerencia = t1.CodGop
                      });

            if (gerencia != String.Empty)
                qr = qr.Where(x => x.Gerencia == gerencia);

            return Ok(await qr.Distinct().AsNoTracking().ToListAsync());
        }
    }
}
