using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{

    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("COS_SUBFAMILIUM")]
    public partial class CosSubfamilium
    {
        [Column("ID")]
        public string Id { get; set; } = null!;
        [Column("NOMBRE")]
        public string Nombre { get; set; } = null!;
        [Column("NOMBREFAMILIA")]
        public string Nombrefamilia { get; set; } = null!;
        [Column("IDFAMILIA")]
        public string Idfamilia { get; set; } = null!;
        [Column("DATAREADID")]
        public string Dataareaid { get; set; } = null!;
        [Column("RECVERSION")]
        public int Recversion { get; set; }
        [Column("RECID")]
        public long Recid { get; set; }
    }
}
