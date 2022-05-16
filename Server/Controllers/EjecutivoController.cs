using Microsoft.AspNetCore.Mvc;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjecutivoController : ControllerBase
    {
        private readonly PptoCeContext _pptoCeContext;

        public EjecutivoController(PptoCeContext pptoCeContext)
        {
            _pptoCeContext = pptoCeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<TblEcRecurso>>> GetCasinos()
        {
            var ejecutivos = await _pptoCeContext.TblEcRecurso.Where(x => x.IdArea == 5).AsNoTracking().ToListAsync();

            return Ok(ejecutivos);
        }
    }
}
