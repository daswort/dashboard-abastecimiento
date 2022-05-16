using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.Cerberus
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("vt_articulosAx")]
    public partial class VtArticulosAx
    {
        [Column("itemGroupId")]
        public string? ItemGroupId { get; set; }
        [Column("articuloId")]
        public string? ArticuloId { get; set; }
        [Column("articuloName")]
        public string? ArticuloName { get; set; }
        [Column("inventDimId")]
        public string? InventDimId { get; set; }
        [Column("ce_variable")]
        public string? CeVariable { get; set; }
        [Column("medida")]
        public string? Medida { get; set; }
        [Column("PRICE")]
        public int? Price { get; set; }
        [Column("articuloNameAlias")]
        public string? ArticuloNameAlias { get; set; }
        [Column("COUNTGROUPID")]
        public string? CountGroupId  { get; set; }
        [Column("AGRUPAREB")]
        public string? Agrupareb { get; set; }
        [Column("grupoimpuestoarticulo")]
        public string? GrupoImpuestoArticulo { get; set; }
        [Column("dataareaid")]
        public string? Dataareaid { get; set; }
    }
}
