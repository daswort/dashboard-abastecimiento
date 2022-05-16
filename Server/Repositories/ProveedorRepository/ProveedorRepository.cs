namespace DashboardAbast.Server.Repositories.ProveedorRepository
{
    public class ProveedorRepository : Repository<TblProveedore>, IProveedorRepository
    {
        public ProveedorRepository(PptoCeContext context)
            : base(context)
        {
        }

        public IQueryable<TblProveedore> GetProveedoresByListOfIDs(ProveedorParametros parametros)
        {
            var query = (from t1 in PptoCeContext.Set<TblProveedore>()
                         where t1.ProveedorId != "11111111-1" && t1.ProveedorId != "78796360-2"
                         select new TblProveedore {
                            ProveedorId = t1.ProveedorId,
                            ProveedorAlias = t1.ProveedorAlias
                         });

            if (parametros.ListaRut.Count > 0)
                return query.Where(x => parametros.ListaRut.Contains(x.ProveedorId));

            return query;
        }

        public PptoCeContext PptoCeContext
        {
            get { return _dbContext as PptoCeContext; }
        }
    }
}
