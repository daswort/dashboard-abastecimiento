using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    [NotMapped]
    public class StGerente : StPersonal
    {
        public StCentroCosto? CentroCosto { get; set; }
    }
}
