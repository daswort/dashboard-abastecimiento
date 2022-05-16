using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [NotMapped]
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_tipo_compra_alimento")]
    public partial class TblTipoCompraAlimento
    {
        //public TblTipoCompraAlimento()
        //{
        //    TblOrdenCompras = new HashSet<TblOrdenCompra>();
        //}

        public int IdTipoCompraAlimento { get; set; }
        public string? TipoCompraAlimento { get; set; }
        public string? Descripcion { get; set; }

        //public virtual ICollection<TblOrdenCompra> TblOrdenCompras { get; set; }
    }
}
