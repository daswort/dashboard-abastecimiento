using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("tbl_ordenCompra")]
    public partial class TblOrdenCompra
    {
        public int IdOrdenCompra { get; set; }
        public string Division { get; set; } = null!;
        public string Gop { get; set; } = null!;
        public string Jop { get; set; } = null!;
        public int Anno { get; set; }
        public int Mes { get; set; }
        public string Almacen { get; set; } = null!;
        public string Casino { get; set; } = null!;
        public int? IdTipoOrden { get; set; }
        public int? IdFamilia { get; set; }
        public string? AporteMeta { get; set; }
        public string? Divisa { get; set; }
        public string? Conjunto { get; set; }
        public string? CtaFacturacion { get; set; }
        public string? CtaProveedor { get; set; }
        public string? Rapell { get; set; }
        public string? Motivo { get; set; }
        public DateTime? Fentrega { get; set; }
        public DateTime? Fcreacion { get; set; }
        public DateTime? FechaProceso { get; set; }
        public DateTime? FecConsumoDesde { get; set; }
        public DateTime? FecConsumoHasta { get; set; }
        public string? Sitio { get; set; }
        public string? FolioAx { get; set; }
        public string? CodOrdenCompra { get; set; }
        public string? Observacion { get; set; }
        public int? IdTipoCompraAlimento { get; set; }

        /// <summary>
        /// valor 0 para eliminado; 1 o NULL para activo
        /// </summary>
        public int? Estado { get; set; }
        public bool? CeCompletaDetalleCompra { get; set; }
        /// <summary>
        /// Nulo o &apos;0&apos;, no procesar, &apos;1&apos; procesar dentro de centralizado
        /// </summary>
        public int? Procesar { get; set; }
        public int? VbJop { get; set; }
        public string? IdSession { get; set; }
        public string? Origen { get; set; }
        public string? AlmacenSolicitante { get; set; }
        public int? IdMinuta { get; set; }

        public virtual TblFamilia? IdFamiliaNavigation { get; set; }
        
        public virtual TblTipoCompraAlimento? IdTipoCompraAlimentoNavigation { get; set; }
    }
}
