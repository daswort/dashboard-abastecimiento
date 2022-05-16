namespace DashboardAbast.Server.Repositories.CentroCostoRepository
{
    public class CentroCostoRepository : Repository<CentroCosto>, ICentroCostoRepository
    {
        public CentroCostoRepository(CerberusMinutaContext context) : base(context)
        {
        }

        public CerberusMinutaContext CerberusMinutaContext
        {
            get { return _dbContext as CerberusMinutaContext; }
        }

        public IQueryable<CentroCosto> ObtenerCentroCostos(CentroCostoParametros parametros)
        {
            var qr = (from t1 in CerberusMinutaContext.Set<VtJopGopAx>()
                      select new CentroCosto()
                      {
                          Codigo = t1.Cc,
                          Nombre = t1.Name
                      });
            if (parametros.ListaId.Count() > 0)
                qr = qr.Where(x => parametros.ListaId.Contains(x.Codigo));

            return qr;
        }
    }
}