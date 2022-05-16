using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("CE_DocParaAnalizar")]
    public partial class CeDocParaAnalizar
    {
        [Column("ID_Interno", TypeName = "decimal(32,0)")]
        public decimal IdInterno { get; set; }
        [Column("Folio")]
        public double? Folio { get; set; }
        [Column("Tipo")]
        public string? Tipo { get; set; }
        [Column("[Estado Recepción]")]
        public string? EstadoRecepción { get; set; }
        [Column("[Fecha Recepción]")]
        public string? FechaRecepción { get; set; }
        [Column("[Estado Conciliación]")]
        public string? EstadoConciliación { get; set; }
        [Column("[Estado Documento]")]
        public string? EstadoDocumento { get; set; }
        [Column("[Fecha Aceptación]")]
        public string? FechaAceptación { get; set; }
        [Column("[Fecha Emisión]")]
        public DateTime? FechaEmisión { get; set; }
        [Column("[Fecha Recibo Mercaderia]")]
        public string? FechaReciboMercaderia { get; set; }
        [Column("[Estado Recibo Mercaderia]")]
        public string? EstadoReciboMercaderia { get; set; }
        [Column("[Monto Total]")]
        public double? MontoTotal { get; set; }
        [Column("[Estado Pago]")]
        public string? EstadoPago { get; set; }
        [Column("[Centro de Gestión]")]
        public string? CentroDeGestión { get; set; }
        [Column("[Nombre Sucursal]")]
        public string? NombreSucursal { get; set; }
        [Column("[Rut Emisor]")]
        public string? RutEmisor { get; set; }
        [Column("[Razon Social Emisor]")]
        public string? RazonSocialEmisor { get; set; }
        [Column("[Rut Receptor]")]
        public string? RutReceptor { get; set; }
        [Column("[Razon Social Receptor]")]
        public string? RazonSocialReceptor { get; set; }
        [Column("Referencias")]
        public string? Referencias { get; set; }
        [Column("Largo")]
        public double? Largo { get; set; }
        [Column("F21")]
        public string? F21 { get; set; }
        [Column("[Fecha de Ingreso]")]
        public string? FechaDeIngreso { get; set; }
        [Column("Integrada")]
        public string? Integrada { get; set; }
        [Column("[Fecha Recepcion Sii]")]
        public string? FechaRecepcionSii { get; set; }
        [Column("[Tipo Reclamo]")]
        public string? TipoReclamo { get; set; }
        [Column("Obs")]
        public string? Obs { get; set; }
        [Column("OC")]
        public string? Oc { get; set; }
        [Column("FEmision")]
        public DateTime? Femision { get; set; }
        [Column("FDespachoOC")]
        public DateTime? FdespachoOc { get; set; }
        [Column("origen")]
        public string? Origen { get; set; }
        [Column("FechaProceso")]
        public DateTime? FechaProceso { get; set; }
        /// <summary>
        /// 0: Integrado , 1: Procesado, 2: Referenciado
        /// </summary>
        [Column("estado")]
        public int? Estado { get; set; }
        [Column("NombreArchivo")]
        public string? NombreArchivo { get; set; }
        [Column("FechaVencimientoDTE")]
        public DateTime? FechaVencimientoDte { get; set; }
        [Column("DireccionDestino")]
        public string? DireccionDestino { get; set; }
    }
}
