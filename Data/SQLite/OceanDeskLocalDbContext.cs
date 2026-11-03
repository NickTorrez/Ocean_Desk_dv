using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data.SQLite.Entities;

namespace Ocean_Desk_dv.Data.SQLite;

/// <summary>
/// Contexto exclusivo de SQLite. No debe reemplazar ni reutilizar
/// OceanDeskDbContext, que continúa conectado a SQL Server.
/// </summary>
public sealed class OceanDeskLocalDbContext : DbContext
{
    public OceanDeskLocalDbContext()
    {
    }

    public OceanDeskLocalDbContext(
        DbContextOptions<OceanDeskLocalDbContext> options)
        : base(options)
    {
    }

    public DbSet<LocalCustomer> LocalCustomers => Set<LocalCustomer>();

    public DbSet<OfflineOperation> OfflineOperations => Set<OfflineOperation>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(
                OceanDeskLocalDbContextFactory.BuildConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocalCustomer>(entity =>
        {
            entity.ToTable("LocalCustomer");

            entity.HasKey(e => e.LocalCustomerId);

            entity.Property(e => e.FirstName)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(80)
                .IsRequired();

            entity.Property(e => e.Phone)
                .HasMaxLength(20);

            entity.Property(e => e.SyncStatus)
                .HasConversion<string>()
                .HasMaxLength(24)
                .IsRequired();

            entity.Property(e => e.LastSyncError)
                .HasMaxLength(2000);

            entity.HasIndex(e => e.ServerCustomerId)
                .IsUnique()
                .HasFilter("\"ServerCustomerId\" IS NOT NULL");

            entity.HasIndex(e => new { e.SyncStatus, e.CreatedAtUtc });
            entity.HasIndex(e => e.Phone);
        });

        modelBuilder.Entity<OfflineOperation>(entity =>
        {
            entity.ToTable("OfflineOperation");

            entity.HasKey(e => e.OperationId);

            entity.Property(e => e.EntityType)
                .HasMaxLength(64)
                .IsRequired();

            entity.Property(e => e.Action)
                .HasMaxLength(32)
                .IsRequired();

            entity.Property(e => e.PayloadJson)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasConversion<string>()
                .HasMaxLength(24)
                .IsRequired();

            entity.Property(e => e.LastError)
                .HasMaxLength(2000);

            entity.HasIndex(e => new
            {
                e.Status,
                e.NextAttemptAtUtc,
                e.CreatedAtUtc
            });

            entity.HasIndex(e => new
            {
                e.EntityType,
                e.LocalRecordId
            });
        });
    }
}
