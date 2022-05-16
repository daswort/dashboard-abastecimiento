namespace DashboardAbast.Server.Repositories.RecepcionFolioRepository
{
    public class RecepcionFolioRepository : Repository<OcRecepcionFolio>, IRecepcionFolioRepository
    {
        public RecepcionFolioRepository(CerberusContext context) : base(context)
        {
        }

        public IQueryable<OcRecepcionFolio> ObtenerOcRecepcionadas(OcNoRecepcionadasParametros parametros)
        {
            DateTime fechaIni = parametros.FechaIni.AddDays(-7);
            DateTime fechaFin = parametros.FechaFin.AddDays(1).AddSeconds(-1);

            System.Diagnostics.Debug.WriteLine("\n################ FechaIniRecep: " + fechaIni);
            System.Diagnostics.Debug.WriteLine("\n################ FechaFinRecep: " + fechaFin);

            var query = (from t1 in CerberusContext.Set<RecepcionFolio>()
                         join t2 in CerberusContext.Set<RecepcionFoliosCantidade>() on t1.Idfolio equals t2.Idfolio
                         where t1.IdEstadoRecepcion != 2 && t1.HoraRecepcion >= fechaIni && t1.HoraRecepcion <= fechaFin
                         select new OcRecepcionFolio()
                         {
                             NumOc = t1.NumeroOrdenCompra,
                             CentroCosto = t1.CentroCosto,
                             CodigoProducto = t2.IdProducto
                         });

            if (parametros.CentrosCosto.Any())
                query = query.Where(x => parametros.CentrosCosto.Contains(x.CentroCosto));

            return query;
        }

        public CerberusContext CerberusContext
        {
            get { return _dbContext as CerberusContext; }
        }
    }
}
