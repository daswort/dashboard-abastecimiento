namespace DashboardAbast.Server.Repositories.OcIConstruyeRepository
{
    public interface ITblIconstruyeOcPasoRepository : IRepository<TblIconstruyeOcPaso>
    {
        IQueryable<OcNoRecepcionada> GetOrdenesCompraVigentesByFechaDespacho(OcNoRecepcionadasParametros parametros);
    }

}
