using DashboardAbast.Server.Extensions.NoLockExtension;
using Microsoft.EntityFrameworkCore.Query;

namespace DashboardAbast.Server.Data
{
    public partial class CerberusContext : DbContext
    {
        public CerberusContext(DbContextOptions<CerberusContext> options) : base(options)
        {
        }

        public virtual DbSet<RecepcionFolio> RecepcionFolios { get; set; } = null!;
        public virtual DbSet<RecepcionFoliosCantidade> RecepcionFoliosCantidades { get; set; } = null!;
        public virtual DbSet<VtArticulosAx> VtArticulosAxes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
