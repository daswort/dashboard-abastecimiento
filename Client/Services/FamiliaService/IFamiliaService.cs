namespace DashboardAbast.Client.Services.FamiliaService
{
    public interface IFamiliaService
    {
        List<CosFamilium> Familias { get; set; }

        Task GetFamilias();
    }
}