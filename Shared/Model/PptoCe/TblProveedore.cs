using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_proveedores")]
    public partial class TblProveedore
    {
        public string? ProveedorId { get; set; }
        public string? ProveedorName { get; set; }
        public string? ProveedorAlias { get; set; }
        public string? CtaFacturacion { get; set; }
        public int? Dia { get; set; }
        public int? Hora { get; set; }
        public bool? ProveedorRapell { get; set; }
        public double? DespMinimo { get; set; }
        public int? PorcentajeSobreMinimo { get; set; }
        public string? Clave { get; set; }
    }
}
