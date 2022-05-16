namespace DashboardAbast.Server.Repositories.EjecutivoRepository
{
    public interface IEjecutivoRepository : IRepository<Ejecutivo>
    {
        IQueryable<Ejecutivo> ObtenerEjecutivos(EjecutivoParametros parametros);

        IQueryable<string> ObtenerListaCentroCosto(EjecutivoParametros parametros);
    }
}