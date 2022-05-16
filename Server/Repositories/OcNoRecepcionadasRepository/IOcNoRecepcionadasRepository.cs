namespace DashboardAbast.Server.Repositories.OcNoRecepcionadasRepository
{
    public interface IOcNoRecepcionadasRepository : IRepository<OcNoRecepcionada>
    {
        IQueryable<OcNoRecepcionada> ObtenerOcNoRecepcionadas(OcNoRecepcionadasParametros parametros);
    }
}