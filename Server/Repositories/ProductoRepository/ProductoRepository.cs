namespace DashboardAbast.Server.Repositories.ProductoRepository
{
    public class ProductoRepository : Repository<VtArticulosAx>, IProductoRepository
    {
        public ProductoRepository(CerberusContext context)
            : base(context)
        {
        }

        public IQueryable<VtArticulosAx> GetProductosAll(ProductoParametros parametros)
        {
            var query = (from t1 in CerberusContext.Set<VtArticulosAx>()
                         select new VtArticulosAx() {
                            ArticuloId = t1.ArticuloId,
                            ArticuloNameAlias = t1.ArticuloNameAlias,
                            Price = t1.Price
                         });

            if (parametros.ListaCodigo.Any())
                query = query.Where(x => parametros.ListaCodigo.Contains(x.ArticuloId));

            return query;
        }

        public CerberusContext CerberusContext
        {
            get { return _dbContext as CerberusContext; }
        }
    }
}
