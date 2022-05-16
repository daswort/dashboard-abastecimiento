namespace DashboardAbast.Server.Repositories.ProveedorRepository
{
    public interface IProveedorRepository : IRepository<TblProveedore>
    {
        //IQueryable<TblProveedore> GetProveedoresByListOfIDs(List<string>? pProveedores = null);
        IQueryable<TblProveedore> GetProveedoresByListOfIDs(ProveedorParametros parametros);
    }
}
