using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ocean_Desk_dv.Models.Entities;
using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Data;

public partial class OceanDeskDbContext : DbContext
{
    public OceanDeskDbContext()
    {
    }

    public OceanDeskDbContext(DbContextOptions<OceanDeskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CashMovement> CashMovements { get; set; }

    public virtual DbSet<CashRegister> CashRegisters { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<KitchenOrder> KitchenOrders { get; set; }

    public virtual DbSet<KitchenOrderDetail> KitchenOrderDetails { get; set; }

    public virtual DbSet<KitchenOrderHistory> KitchenOrderHistories { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SalePayment> SalePayments { get; set; }

    public virtual DbSet<TableRestaurant> TableRestaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string? connectionString = configuration.GetConnectionString("OceanDeskDbConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CashMovement>(entity =>
        {
            entity.HasKey(e => e.CashMovementId).HasName("PK__CashMove__BB9938A6AFC01AF5");

            entity.ToTable("CashMovement");

            entity.HasIndex(e => e.CashRegisterId, "IX_CashMovement_CashRegisterId");

            entity.HasIndex(e => e.MovementDateTime, "IX_CashMovement_MovementDateTime");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Concept).HasMaxLength(250);
            entity.Property(e => e.MovementDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.MovementType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Reference).HasMaxLength(100);

            entity.HasOne(d => d.CashRegister).WithMany(p => p.CashMovements)
                .HasForeignKey(d => d.CashRegisterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CashMovement_CashRegister");

            entity.HasOne(d => d.Sale).WithMany(p => p.CashMovements)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK_CashMovement_Sale");
        });

        modelBuilder.Entity<CashRegister>(entity =>
        {
            entity.HasKey(e => e.CashRegisterId).HasName("PK__CashRegi__7B5CAE9427202BDE");

            entity.ToTable("CashRegister", tb => tb.HasTrigger("TRG_CashRegister_CalculateDifference"));

            entity.Property(e => e.ActualCash).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ClosingDateTime).HasPrecision(0);
            entity.Property(e => e.Difference).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ExpectedCash).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OpeningAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.OpeningDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Open");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB53CC24C48");

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.CustomerId, "IX_Invoice_CustomerId");

            entity.HasIndex(e => e.IssueDateTime, "IX_Invoice_IssueDateTime");

            entity.HasIndex(e => e.InvoiceNumber, "UQ_Invoice_Number").IsUnique();

            entity.HasIndex(e => e.SaleId, "UQ_Invoice_Sale").IsUnique();

            entity.Property(e => e.CancellationDateTime).HasPrecision(0);
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.Discount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IssueDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Issued");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Sale).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_Sale");
        });

        modelBuilder.Entity<KitchenOrder>(entity =>
        {
            entity.HasKey(e => e.KitchenOrderId).HasName("PK__KitchenO__4F08F9852FB26E1F");

            entity.ToTable("KitchenOrder", tb => tb.HasTrigger("TRG_KitchenOrder_AuditStatus"));

            entity.HasIndex(e => e.ReceptionDateTime, "IX_KitchenOrder_ReceptionDateTime");

            entity.HasIndex(e => e.Status, "IX_KitchenOrder_Status");

            entity.HasIndex(e => e.SaleId, "UQ_KitchenOrder_Sale").IsUnique();

            entity.Property(e => e.DeliveredDateTime).HasPrecision(0);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PreparationStartDateTime).HasPrecision(0);
            entity.Property(e => e.Priority)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValue("Normal");
            entity.Property(e => e.ReadyDateTime).HasPrecision(0);
            entity.Property(e => e.ReceptionDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Sale).WithOne(p => p.KitchenOrder)
                .HasForeignKey<KitchenOrder>(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KitchenOrder_Sale");
        });

        modelBuilder.Entity<KitchenOrderDetail>(entity =>
        {
            entity.HasKey(e => e.KitchenOrderDetailId).HasName("PK__KitchenO__C2B2DB19BDDBE7F0");

            entity.ToTable("KitchenOrderDetail");

            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.KitchenOrder).WithMany(p => p.KitchenOrderDetails)
                .HasForeignKey(d => d.KitchenOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KitchenOrderDetail_KitchenOrder");

            entity.HasOne(d => d.SaleDetail).WithMany(p => p.KitchenOrderDetails)
                .HasForeignKey(d => d.SaleDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KitchenOrderDetail_SaleDetail");
        });

        modelBuilder.Entity<KitchenOrderHistory>(entity =>
        {
            entity.HasKey(e => e.KitchenOrderHistoryId).HasName("PK__KitchenO__B3F43896A5870401");

            entity.ToTable("KitchenOrderHistory");

            entity.Property(e => e.ChangeDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.NewStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.PreviousStatus)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.KitchenOrder).WithMany(p => p.KitchenOrderHistories)
                .HasForeignKey(d => d.KitchenOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KitchenOrderHistory_KitchenOrder");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F2406C71C84");

            entity.ToTable("Reservation", tb => tb.HasTrigger("TRG_Reservation_UpdateTableStatus"));

            entity.HasIndex(e => e.CustomerId, "IX_Reservation_CustomerId");

            entity.HasIndex(e => e.ReservationDate, "IX_Reservation_ReservationDate");

            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.RegistrationDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ReservationTime).HasPrecision(0);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_Reservation_Table");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FF8C7610D9");

            entity.ToTable("Sale");

            entity.HasIndex(e => e.CustomerId, "IX_Sale_CustomerId");

            entity.HasIndex(e => e.SaleDateTime, "IX_Sale_SaleDateTime");

            entity.Property(e => e.Discount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SaleDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Completed");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FE2F98DDC4");

            entity.ToTable("SaleDetail");

            entity.HasIndex(e => e.ProductId, "IX_SaleDetail_ProductId");

            entity.HasIndex(e => e.SaleId, "IX_SaleDetail_SaleId");

            entity.Property(e => e.Discount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Sale");
        });

        modelBuilder.Entity<SalePayment>(entity =>
        {
            entity.HasKey(e => e.SalePaymentId).HasName("PK__SalePaym__C5E7A5450C0A25B3");

            entity.ToTable("SalePayment");

            entity.HasIndex(e => e.SaleId, "IX_SalePayment_SaleId");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.PaymentDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Reference).HasMaxLength(100);

            entity.HasOne(d => d.Sale).WithMany(p => p.SalePayments)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalePayment_Sale");
        });

        modelBuilder.Entity<TableRestaurant>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__TableRes__7D5F01EEAB5A39E2");

            entity.ToTable("TableRestaurant");

            entity.HasIndex(e => e.TableNumber, "UQ_TableRestaurant_Number").IsUnique();

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Available");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
