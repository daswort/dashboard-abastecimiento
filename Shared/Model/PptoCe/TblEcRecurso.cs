using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_ec_recurso")]
    public partial class TblEcRecurso
    {
        public int IdRecurso { get; set; }
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public int? IdArea { get; set; }
        public int? Cargo { get; set; }
    }
}
