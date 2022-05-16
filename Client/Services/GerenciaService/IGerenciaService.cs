namespace DashboardAbast.Client.Services.GerenciaService
{
    public interface IGerenciaService
    {
        List<Gerencia> Gerencias { get; set; }

        Task GetGerencias(string division = "");
    }
}
