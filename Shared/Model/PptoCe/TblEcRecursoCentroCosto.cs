using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_ec_recurso_centroCosto")]
    public partial class TblEcRecursoCentroCosto
    {
        public int IdRecurso { get; set; }
        public string CentroCosto { get; set; } = null!;
        public string? UsuarioIngresa { get; set; }
        public DateTime? FechaIngresa { get; set; }
    }
}
