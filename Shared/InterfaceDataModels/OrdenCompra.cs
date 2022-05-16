using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.InterfaceDataModels
{
    [NotMapped]
    [Microsoft.EntityFrameworkCore.Keyless]
    public partial class OrdenCompra
    {
        public string NumOc { get; set; }
        public string? FolioFact { get; set; }
        public string IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime FechaDespacho { get; set; }
        public string IdCasino { get; set; }
        public string NombreCasino { get; set; }
        public string? Familia { get; set; }
        public string? CosFamilia { get; set; }
        public string? TipoCompra { get; set; }
        public int CantLineas { get; set; }
        public DetalleOrdenCompra DetalleOrdenCompra { get; set; }
    }
}
