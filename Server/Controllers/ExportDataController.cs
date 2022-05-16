using Microsoft.AspNetCore.Mvc;

namespace DashboardAbast.Server.Controllers
{
    public partial class ExportDataController : ExportController
    {
        private readonly PptoCeContext _pptoCeContext;
        private readonly CerberusMinutaContext _cerberusMinutaContext;
        private readonly AxCasinoContext _axCasinoContext;

        public ExportDataController(PptoCeContext pptoCeContext, CerberusMinutaContext cerberusMinutaContext, AxCasinoContext axCasinoContext)
        {
            _pptoCeContext = pptoCeContext;
            _cerberusMinutaContext = cerberusMinutaContext;
            _axCasinoContext = axCasinoContext;
        }

        [HttpGet("exportar/tabla1/excel")]
        public FileStreamResult ExportarTabla1AToExcel()
        {
            return ToExcel(ApplyQuery(_pptoCeContext.TablaPorCasino, Request.Query));
        }
    }
}
