namespace DashboardAbast.Server.ContextFactory
{
    public class AxCasinoScopedFactory : IDbContextFactory<AxCasinoContext>
    {
        private readonly IDbContextFactory<AxCasinoContext> _pooledFactory;

        public AxCasinoScopedFactory(
            IDbContextFactory<AxCasinoContext> pooledFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _pooledFactory = pooledFactory;
        }

        public AxCasinoContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            return context;
        }
    }
}
