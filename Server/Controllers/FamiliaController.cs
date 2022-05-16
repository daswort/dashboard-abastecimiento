using Microsoft.AspNetCore.Mvc;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly AxCasinoContext _axCasinoContext;
        public FamiliaController(AxCasinoContext axCasinoContext)
        {
            _axCasinoContext = axCasinoContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CosFamilium>>> GetFamilias()
        {
            var familias = await _axCasinoContext.CosFamilium.AsNoTracking().ToListAsync();
            return Ok(familias);
        }
    }
}