using System.Text.Json;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    public class StOrdenCompra
    {
        public string Numero { get; set; }
        public string? TipoCompra { get; set; }
        public StFactura? Factura { get; set; }
        public StProveedor? Proveedor { get; set; }
        public StCentroCosto? CentroCosto { get; set; }
        public List<StDetalleOrdenCompra>? Items { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public int? CantidadLineasOriginales { get; set; }
        public int? CantidadLineasRecepcionadas { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
    }
}
