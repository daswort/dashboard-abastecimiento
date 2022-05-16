namespace DashboardAbast.Shared.QueryModels
{
    public class QrOrdenCompraLinea
    {
        public string? NumOc { get; set; }
        public string? FolioFact { get; set; }
        public string? ReferenciasOc { get; set; }
        public string? IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? DetalleNumOc { get; set; }
        public string? CodigoProducto { get; set; }
        public string? NombreProducto { get; set; }
        public string? Familia { get; set; }
        public string? CosFamilia { get; set; }
        public string? TipoCompra { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? Unidad { get; set; }
        public string? IdCasino { get; set; }
        public string? NombreCasino { get; set; }
        public DateTime FechaDespacho { get; set; }
        public string? Dataareaid { get; set; }
        public int? CantLnOriginal { get; set; }
        public int? CantLnRecepcionadas { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
    }
}
