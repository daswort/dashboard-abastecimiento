namespace DashboardAbast.Shared.StandarizedDbModel
{
    public class StDetalleOrdenCompra
    {
        public string DetalleNumOc { get; set; }
        public StProducto Producto { get; set; }
        public Decimal? Cantidad { get; set; }
    }
}
