using System.Linq;
using System.Text.Json;

namespace DashboardAbast.Server.Repositories.EjecutivoRepository
{
    public class EjecutivoRepository : Repository<Ejecutivo>, IEjecutivoRepository
    {
        public EjecutivoRepository(PptoCeContext context) : base(context)
        {
        }

        public PptoCeContext PptoCeContext
        {
            get { return _dbContext as PptoCeContext; }
        }

        public IQueryable<Ejecutivo> ObtenerEjecutivos(EjecutivoParametros parametros)
        {
            var qr = (from t1 in PptoCeContext.Set<TblEcRecurso>()
                        join t2 in PptoCeContext.Set<TblEcRecursoCentroCosto>() on t1.IdRecurso equals t2.IdRecurso
                        where t1.IdArea == 5
                        select new Ejecutivo()
                        {
                            Rut = t1.Rut,
                            Nombre = t1.Nombre,
                            CentroCosto = t2.CentroCosto
                        });

            if (parametros.ListaRut.Count() > 0)
                qr = qr.Where(x => parametros.ListaRut.Contains(x.Rut));

            return qr;
        }

        public IQueryable<string> ObtenerListaCentroCosto(EjecutivoParametros parametros)
        {
            var qr = (from t1 in PptoCeContext.Set<TblEcRecurso>()
                      join t2 in PptoCeContext.Set<TblEcRecursoCentroCosto>() on t1.IdRecurso equals t2.IdRecurso
                      where t1.IdArea == 5
                      select new { t1.Rut, t2.CentroCosto });

            if (parametros.ListaRut.Count() > 0)
                qr = qr.Where(x => parametros.ListaRut.Contains(x.Rut));

            return qr.Select(x => x.CentroCosto).Distinct();
        }
    }
}