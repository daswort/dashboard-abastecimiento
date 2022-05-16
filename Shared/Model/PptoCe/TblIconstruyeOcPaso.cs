using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_iconstruye_oc_paso")]
    public partial class TblIconstruyeOcPaso
    {
        public string? NumOc { get; set; }
        public string? EstadoDoc { get; set; }
        public string? RutProveedor { get; set; }
        public string? CantidadActualOc { get; set; }
        public string? CantidadOriginal { get; set; }
        public string? CantidadRechazada { get; set; }
        public string? CantidadRecibida { get; set; }
        public string? CodigoProducto { get; set; }
        public string? Descripcion { get; set; }
        public string? EstadoLinea { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? UnidadMedida { get; set; }
        public DateTime? FechaCarga { get; set; }
        public string? CentroCosto { get; set; }
    }
}
