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

    public DbSet<LocalProduct> LocalProducts => Set<LocalProduct>();

    public DbSet<LocalRestaurantTable> LocalRestaurantTables =>
        Set<LocalRestaurantTable>();

    public DbSet<LocalCashRegister> LocalCashRegisters =>
    Set<LocalCashRegister>();

    public DbSet<LocalCashMovement> LocalCashMovements =>
        Set<LocalCashMovement>();

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

        modelBuilder.Entity<LocalProduct>(entity =>
        {
            entity.ToTable("LocalProduct");

            entity.HasKey(e => e.ServerProductId);

            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasIndex(e => e.ProductCode)
                .IsUnique();
        });

        modelBuilder.Entity<LocalRestaurantTable>(entity =>
        {
            entity.ToTable("LocalRestaurantTable");

            entity.HasKey(e => e.ServerTableId);

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsRequired();

            entity.HasIndex(e => e.TableNumber)
                .IsUnique();
        });


        modelBuilder.Entity<LocalCashRegister>(entity =>
        {
            entity.ToTable("LocalCashRegister");

            entity.HasKey(e => e.LocalCashRegisterId);

            entity.Property(e => e.LocalCashRegisterId)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.Origin)
                .HasConversion<string>()
                .HasMaxLength(24)
                .IsRequired();

            entity.Property(e => e.SyncStatus)
                .HasConversion<string>()
                .HasMaxLength(24)
                .IsRequired();

            entity.Property(e => e.LastSyncError)
                .HasMaxLength(2000);

            entity.HasIndex(e => e.ServerCashRegisterId)
                .IsUnique()
                .HasFilter("\"ServerCashRegisterId\" IS NOT NULL");

            entity.HasIndex(e => new
            {
                e.OpeningUserId,
                e.Status,
                e.CachedAtUtc
            });

            entity.HasMany(e => e.Movements)
                .WithOne()
                .HasForeignKey(m => m.LocalCashRegisterId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<LocalCashMovement>(entity =>
        {
            entity.ToTable("LocalCashMovement");

            entity.HasKey(e => e.LocalCashMovementId);

            entity.Property(e => e.MovementType)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(e => e.Concept)
                .HasMaxLength(250)
                .IsRequired();

            entity.Property(e => e.Reference)
                .HasMaxLength(100);

            entity.Property(e => e.Notes)
                .HasMaxLength(500);

            entity.Property(e => e.SyncStatus)
                .HasConversion<string>()
                .HasMaxLength(24)
                .IsRequired();

            entity.Property(e => e.LastSyncError)
                .HasMaxLength(2000);

            entity.HasIndex(e => e.ServerCashMovementId)
                .IsUnique()
                .HasFilter("\"ServerCashMovementId\" IS NOT NULL");

            entity.HasIndex(e => new
            {
                e.LocalCashRegisterId,
                e.MovementDateTime
            });
        });

    }
}