namespace DashboardAbast.Server.ContextFactory
{
    public class CerberusMinutaScopedFactory
    {
        private readonly IDbContextFactory<CerberusMinutaContext> _pooledFactory;

        public CerberusMinutaScopedFactory(
            IDbContextFactory<CerberusMinutaContext> pooledFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _pooledFactory = pooledFactory;
        }

        public CerberusMinutaContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            return context;
        }
    }
}
