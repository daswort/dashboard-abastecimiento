using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    [NotMapped]
    public class StJefe : StPersonal
    {
        StCentroCosto? CentroCosto { get; set; }
        StGerente? Gerente { get; set; }
    }
}
