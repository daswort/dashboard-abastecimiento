namespace DashboardAbast.Client.Services.CentroCostoService
{
    public interface ICentroCostoService
    {
        List<CentroCosto> CentrosCosto { get; set;  }
        
        Task GetCentrosCosto();

        Task GetCentrosCostoPorJefatura(string jefatura = "");

        Task<CentroCosto> GetSingleCentroCosto(string id);
    }
}
