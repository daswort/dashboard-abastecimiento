namespace DashboardAbast.Server.Repositories.RecepcionFolioRepository
{
    public interface IRecepcionFolioRepository : IRepository<OcRecepcionFolio>
    {
        IQueryable<OcRecepcionFolio> ObtenerOcRecepcionadas(OcNoRecepcionadasParametros parametros);
    }
}
