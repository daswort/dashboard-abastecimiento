namespace DashboardAbast.Server.ContextFactory
{
    public class PptoCeScopedFactory : IDbContextFactory<PptoCeContext>
    {
        private readonly IDbContextFactory<PptoCeContext> _pooledFactory;

        public PptoCeScopedFactory(
            IDbContextFactory<PptoCeContext> pooledFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _pooledFactory = pooledFactory;
        }

        public PptoCeContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();            
            return context;
        }
    }
}
