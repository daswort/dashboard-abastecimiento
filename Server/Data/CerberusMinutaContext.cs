using DashboardAbast.Server.Extensions.NoLockExtension;
using Microsoft.EntityFrameworkCore.Query;

namespace DashboardAbast.Server.Data
{
    public partial class CerberusMinutaContext : DbContext
    {
        public virtual DbSet<VtJopGopAx> VtJopGopAxes { get; set; } = null!;

        public CerberusMinutaContext(DbContextOptions<CerberusMinutaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VtJopGopAx>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vt_jopGop_ax");

                entity.Property(e => e.Area)
                    .HasMaxLength(25)
                    .HasColumnName("area")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Calle)
                    .HasMaxLength(250)
                    .HasColumnName("calle")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Cc)
                    .HasMaxLength(25)
                    .HasColumnName("cc")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CcPadre)
                    .HasMaxLength(25)
                    .HasColumnName("ccPadre")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CePremiacionsellos).HasColumnName("ce_premiacionsellos");

                entity.Property(e => e.CeRestacosto).HasColumnName("ce_restacosto");

                entity.Property(e => e.CeResultadogestion).HasColumnName("ce_resultadogestion");

                entity.Property(e => e.CentroCostoCookAndChill)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cierre)
                    .HasColumnType("datetime")
                    .HasColumnName("cierre");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(255)
                    .HasColumnName("cliente")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CodGop)
                    .HasMaxLength(255)
                    .HasColumnName("cod_gop")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CodJop)
                    .HasMaxLength(255)
                    .HasColumnName("cod_jop")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Comuna)
                    .HasMaxLength(25)
                    .HasColumnName("comuna")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Creacioncasino)
                    .HasColumnType("datetime")
                    .HasColumnName("creacioncasino");

                entity.Property(e => e.Dataareaid)
                    .HasMaxLength(4)
                    .HasColumnName("DATAAREAID")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Gop)
                    .HasMaxLength(255)
                    .HasColumnName("gop")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Jop)
                    .HasMaxLength(255)
                    .HasColumnName("jop")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Lat)
                    .HasColumnType("numeric(28, 12)")
                    .HasColumnName("lat");

                entity.Property(e => e.Lon)
                    .HasColumnType("numeric(28, 12)")
                    .HasColumnName("lon");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Perdido).HasColumnName("perdido");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(25)
                    .HasColumnName("provincia")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ProyectoAbierto).HasColumnName("proyectoAbierto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
