namespace DashboardAbast.Server.ContextFactory
{
    public class CerberusScopedFactory
    {
        private readonly IDbContextFactory<CerberusContext> _pooledFactory;

        public CerberusScopedFactory(
            IDbContextFactory<CerberusContext> pooledFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _pooledFactory = pooledFactory;
        }

        public CerberusContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            return context;
        }
    }
}
