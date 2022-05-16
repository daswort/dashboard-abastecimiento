using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.Cerberus
{
    [Table("RecepcionFoliosCantidades")]
    public partial class RecepcionFoliosCantidade
    {
        [Key]
        [Column("idfolio")]
        public long Idfolio { get; set; }
        [Column("idProducto")]
        public string? IdProducto { get; set; }
        [Column("cantidad")]
        public double? Cantidad { get; set; }
        [Column("Unidad")]
        public string? Unidad { get; set; }
        [Column("id")]
        public long Id { get; set; }

        public virtual RecepcionFolio IdfolioNavigation { get; set; } = null!;
    }
}
