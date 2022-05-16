using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.Cerberus
{
    [Table("RecepcionFolios")]
    public partial class RecepcionFolio
    {
        [Key]
        [Column("idfolio")]
        public long Idfolio { get; set; }
        [Column("idEstadoRecepcion")]
        public int? IdEstadoRecepcion { get; set; }
        [Column("numeroOrdenCompra")]
        public string? NumeroOrdenCompra { get; set; }
        [Column("numeroDocumento")]
        public string? NumeroDocumento { get; set; }
        [Column("fechaIniRecepcion")]
        public DateTime? FechaIniRecepcion { get; set; }
        [Column("fechaFinRecepcion")]
        public DateTime? FechaFinRecepcion { get; set; }
        [Column("horaRecepcion")]
        public DateTime? HoraRecepcion { get; set; }
        [Column("tipoDocumento")]
        public string? TipoDocumento { get; set; }
        [Column("fechaCarga")]
        public DateTime? FechaCarga { get; set; }
        /// <summary>
        /// 0 o Null imagen no procesada o en proceso; 1 imagen marcada como PROCESADA
        /// </summary>
        [Column("Estado")]
        public long? Estado { get; set; }
        [Column("FechaProcesada")]
        public DateTime? FechaProcesada { get; set; }
        [Column("CentroCosto")]
        public string? CentroCosto { get; set; }
        [Column("OrigenIngreso")]
        public string? OrigenIngreso { get; set; }
        [Column("Usuario")]
        public string? Usuario { get; set; }
        [Column("EstadoAnulacion")]
        public int? EstadoAnulacion { get; set; }
        [Column("EstadoCosto")]
        public long? EstadoCosto { get; set; }
        [Column("EstadoAbast")]
        public long? EstadoAbast { get; set; }
    }
}
