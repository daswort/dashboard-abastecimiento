namespace DashboardAbast.Shared.Entidades.Modelos
{
    public class OcNoRecepcionada
    {
        public string NumOc { get; set; }
        public double? FolioFact { get; set; }
        public string ReferenciasOc { get; set; }
        public string IdProveedor { get; set; }
        public string DetalleNumOc { get; set; }
        public string CodigoProducto { get; set; }
        public string Familia { get; set; }
        public string CosIdfamilia { get; set; }
        public string CosFamilia { get; set; }
        public string TipoCompra { get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public string CentroCosto { get; set; }
        public DateTime FechaDespacho { get; set; }
        public int? CantLnOriginal { get; set; }
    }
}
