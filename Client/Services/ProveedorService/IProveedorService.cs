namespace DashboardAbast.Client.Services.ProveedorService
{
    public interface IProveedorService
    {
        List<TblProveedore> Proveedores { get; set; }

        Task GetProveedores(DateTime vFechaIni, DateTime vFechaFin);
    }
}