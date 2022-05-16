namespace DashboardAbast.Client.Services.JefaturaService
{
    public interface IJefaturaService
    {
        List<Jefatura> Jefaturas { get; set; }

        Task GetJefaturas(string gerencia = "");
    }
}
