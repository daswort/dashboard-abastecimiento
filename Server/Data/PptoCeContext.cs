using DashboardAbast.Server.Extensions.NoLockExtension;
using Microsoft.EntityFrameworkCore.Query;

namespace DashboardAbast.Server.Data
{
    public partial class PptoCeContext : DbContext
    {
        public PptoCeContext(DbContextOptions<PptoCeContext> options) : base(options)
        {
        }

        public virtual DbSet<TblCasino> TblCasino { get; set; }
        public virtual DbSet<TblFamilia> TblFamilia { get; set; }
        public virtual DbSet<TblOrdenCompra> TblOrdenCompra { get; set; }        
        public virtual DbSet<TblProveedore> TblProveedore { get; set; }
        public virtual DbSet<TblIconstruyeOcPaso> TblIconstruyeOcPaso { get; set; }
        public virtual DbSet<TablaPorCasino> TablaPorCasino { get; set; }
        public virtual DbSet<TblEcRecurso> TblEcRecurso { get; set; }
        public virtual DbSet<TblEcRecursoCentroCosto> TblEcRecursoCentroCosto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCasino>(entity =>
            {
                entity.HasKey(e => e.CentroCosto);

                entity.ToTable("tbl_casino");

                entity.Property(e => e.CentroCosto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo2")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Correo3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo3")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailCasino)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FonoFijo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ModeloCelular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoteBook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCelular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Serie)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
