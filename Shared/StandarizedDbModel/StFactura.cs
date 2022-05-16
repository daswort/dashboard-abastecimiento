using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    [NotMapped]
    public class StFactura
    {
        [Key]
        public string? Codigo { get; set; }
    }
}
