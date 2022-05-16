namespace DashboardAbast.Server.Repositories.ProductoRepository
{
    public interface IProductoRepository : IRepository<VtArticulosAx>
    {
        IQueryable<VtArticulosAx> GetProductosAll(ProductoParametros parametros);
    }
}