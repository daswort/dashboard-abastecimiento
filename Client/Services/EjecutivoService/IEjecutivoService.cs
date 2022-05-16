namespace DashboardAbast.Client.Services.EjecutivoService
{
    public interface IEjecutivoService
    {
        List<TblEcRecurso> Ejecutivos { get; set; }

        Task GetEjecutivos();
    }
}
