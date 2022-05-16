namespace DashboardAbast.Server.Repositories.CentroCostoRepository
{
    public interface ICentroCostoRepository : IRepository<CentroCosto>
    {
        IQueryable<CentroCosto> ObtenerCentroCostos(CentroCostoParametros parametros);
    }
}