namespace DashboardAbast.Client.Services.OrdenCompraService
{
    public interface IOrdenCompraService
    {
        List<TblOrdenCompra> OrdenCompras { get; set; }
        List<ProveedorItem> ProveedorPorCasinos { get; set; }
        List<TablaPorCasino> TablaPorCasino { get; set; }

        Task GetOrdenCompras(string fechaIni, string fechaFin);

        Task GetOrdenesCompraPorCasinoGrafico(string fechaIni, string fechaFin, string casinos);

        Task GetOrdenesCompraPorCasinoTabla(string fechaIni, string fechaFin, string casinos);
    }
}
