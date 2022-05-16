using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("COS_FAMILIA")]
    public partial class CosFamilium
    {
        [Column("NOMBRE")]
        public string? Nombre { get; set; } = null!;
        [Column("ID")]
        public string? Id { get; set; } = null!;
        [Column("DATAAREAID")]
        public string? Dataareaid { get; set; } = null!;
        [Column("RECVERSION")]
        public int Recversion { get; set; }
        [Column("RECID")]
        public long Recid { get; set; }
    }
}
