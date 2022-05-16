namespace DashboardAbast.Shared.InterfaceDataModels
{
    [Microsoft.EntityFrameworkCore.Keyless]
    public partial class TablaPorCasino
    {
        public string IdCasino { get; set; }
        public string NombreCasino { get; set; }
        public string IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string OrdenCompra { get; set; }
    }
}
