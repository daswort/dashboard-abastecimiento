using System.Linq.Expressions;

namespace DashboardAbast.Server.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}