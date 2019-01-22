using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BettingApi.Models
{
    public partial class BettingContext : DbContext
    {
        public BettingContext()
        {
        }

        public BettingContext(DbContextOptions<BettingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoefficientsFootballs> CoefficientsFootballs { get; set; }
        public virtual DbSet<CoefficientsTennis> CoefficientsTennis { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Odds> Odds { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("data source=DESKTOP-1DDVFS6\\SQLEXPRESS;initial catalog=OddsDb;Integrated Security=SSPI;application name=EntityFramework;MultipleActiveResultSets=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<CoefficientsFootballs>(entity =>
            {
                entity.HasIndex(e => e.OddId)
                    .HasName("IX_OddId");

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.HasOne(d => d.Odd)
                    .WithMany(p => p.CoefficientsFootballs)
                    .HasForeignKey(d => d.OddId)
                    .HasConstraintName("FK_dbo.CoefficientsFootballs_dbo.Odds_OddId");
            });

            modelBuilder.Entity<CoefficientsTennis>(entity =>
            {
                entity.HasIndex(e => e.OddId)
                    .HasName("IX_OddId");

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.HasOne(d => d.Odd)
                    .WithMany(p => p.CoefficientsTennis)
                    .HasForeignKey(d => d.OddId)
                    .HasConstraintName("FK_dbo.CoefficientsTennis_dbo.Odds_OddId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Odds>(entity =>
            {
                entity.Property(e => e.BeginingTime).HasColumnType("datetime");
            });
        }
    }
}
