using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [NotMapped]
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_familias")]
    public partial class TblFamilia
    {
        public TblFamilia()
        {
            TblOrdenCompras = new HashSet<TblOrdenCompra>();
        }

        public int IdFamilia { get; set; }
        public string? DescFamilia { get; set; }
        public int? Estado { get; set; }
        /// <summary>
        /// indica contra que valor se debe comparar los valores de COMPRA. &apos;0&apos; contra PPTO; &apos;1&apos;  contra PROY.
        /// </summary>
        public int? Proyectada { get; set; }
        public int? Orden { get; set; }
        public bool RequiereAprobacionEspecial { get; set; }

        public virtual ICollection<TblOrdenCompra> TblOrdenCompras { get; set; }
    }
}
