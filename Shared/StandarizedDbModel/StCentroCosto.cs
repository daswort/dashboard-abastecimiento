using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    [NotMapped]
    public partial class StCentroCosto
    {
        [Key]
        public string Codigo { get; set; }
        public string? Nombre { get; set; }

    }
}
