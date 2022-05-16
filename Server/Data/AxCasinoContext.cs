using DashboardAbast.Server.Extensions.NoLockExtension;
using Microsoft.EntityFrameworkCore.Query;

namespace DashboardAbast.Server.Data
{
    public partial class AxCasinoContext : DbContext
    {
        public AxCasinoContext(DbContextOptions<AxCasinoContext> options) : base(options)
        {
        }

        public DbSet<Vendtable> Vendtable { get; set; }
        public DbSet<Purchtable> Purchtable { get; set; }
        public DbSet<Purchline> Purchline { get; set; }
        public DbSet<Inventlocation> Inventlocation { get; set; }
        public DbSet<CosSubfamilium> CosSubfamilium { get; set; }
        public DbSet<CosFamilium> CosFamilium { get; set; }
        public DbSet<CeDocParaAnalizar> CeDocParaAnalizar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
