using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.CerberusMinuta
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("vt_jopGop_ax")]
    public partial class VtJopGopAx
    {
        public string Cliente { get; set; } = null!;
        public DateTime Creacioncasino { get; set; }
        public string Jop { get; set; } = null!;
        public string CodJop { get; set; } = null!;
        public string Gop { get; set; } = null!;
        public string CodGop { get; set; } = null!;
        public string Dataareaid { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public string Area { get; set; } = null!;
        public string Comuna { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string? Calle { get; set; }
        public int CeResultadogestion { get; set; }
        public int CePremiacionsellos { get; set; }
        public string CcPadre { get; set; } = null!;
        public DateTime Cierre { get; set; }
        public int Perdido { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
        public int CeRestacosto { get; set; }
        public bool? CostoDirecto { get; set; }
        public string? CentroCostoCookAndChill { get; set; }
        public bool ProyectoAbierto { get; set; }
    }
}
