 using System.Linq.Expressions;

namespace DashboardAbast.Server.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }
    }
}
