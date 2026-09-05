using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Models.Entities;

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

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<CashMovement> CashMovements { get; set; }

    public virtual DbSet<CashRegister> CashRegisters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<KitchenOrder> KitchenOrders { get; set; }

    public virtual DbSet<KitchenOrderDetail> KitchenOrderDetails { get; set; }

    public virtual DbSet<KitchenOrderHistory> KitchenOrderHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SalePayment> SalePayments { get; set; }

    public virtual DbSet<TableRestaurant> TableRestaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQL2025DEV;Database=Ocean_Desk_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__A17F2398293C7C15");

            entity.ToTable("AuditLog");

            entity.HasIndex(e => e.RecordId, "IX_AuditLog_RecordId");

            entity.HasIndex(e => new { e.TableName, e.ChangeDateTime }, "IX_AuditLog_TableName_ChangeDateTime");

            entity.Property(e => e.ChangeDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.ChangedBy)
                .HasMaxLength(128)
                .HasDefaultValueSql("(suser_sname())");
            entity.Property(e => e.Operation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CashMovement>(entity =>
        {
            entity.HasKey(e => e.CashMovementId).HasName("PK__CashMove__BB9938A6AFC01AF5");

            entity.ToTable("CashMovement", tb => tb.HasTrigger("TRG_CashMovement_Audit"));

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

            entity.ToTable("CashRegister", tb =>
                {
                    tb.HasTrigger("TRG_CashRegister_Audit");
                    tb.HasTrigger("TRG_CashRegister_CalculateDifference");
                });

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

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "IX_Customer_LastName_FirstName");

            entity.HasIndex(e => e.Phone, "IX_Customer_Phone");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(80);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(80);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB53CC24C48");

            entity.ToTable("Invoice", tb => tb.HasTrigger("TRG_Invoice_Audit"));

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

            entity.ToTable("KitchenOrder", tb =>
                {
                    tb.HasTrigger("TRG_KitchenOrder_Audit");
                    tb.HasTrigger("TRG_KitchenOrder_AuditStatus");
                });

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

            entity.ToTable("KitchenOrderDetail", tb => tb.HasTrigger("TRG_KitchenOrderDetail_Audit"));

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

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCategoryId, "IX_Product_ProductCategoryId");

            entity.HasIndex(e => e.ProductName, "IX_Product_ProductName");

            entity.HasIndex(e => e.ProductCode, "UQ_Product_ProductCode").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.ProductCode).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(150);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.HasIndex(e => e.CategoryName, "UQ_ProductCategory_CategoryName").IsUnique();

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F2406C71C84");

            entity.ToTable("Reservation", tb =>
                {
                    tb.HasTrigger("TRG_Reservation_Audit");
                    tb.HasTrigger("TRG_Reservation_UpdateTableStatus");
                });

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

            entity.ToTable("Sale", tb => tb.HasTrigger("TRG_Sale_Audit"));

            entity.HasIndex(e => e.CustomerId, "IX_Sale_CustomerId");

            entity.HasIndex(e => e.SaleDateTime, "IX_Sale_SaleDateTime");

            entity.HasIndex(e => e.TableId, "IX_Sale_TableId");

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

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Sale_Customer");

            entity.HasOne(d => d.Table).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_Sale_TableRestaurant");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FE2F98DDC4");

            entity.ToTable("SaleDetail", tb => tb.HasTrigger("TRG_SaleDetail_Audit"));

            entity.HasIndex(e => e.ProductId, "IX_SaleDetail_ProductId");

            entity.HasIndex(e => e.SaleId, "IX_SaleDetail_SaleId");

            entity.Property(e => e.Discount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Product");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Sale");
        });

        modelBuilder.Entity<SalePayment>(entity =>
        {
            entity.HasKey(e => e.SalePaymentId).HasName("PK__SalePaym__C5E7A5450C0A25B3");

            entity.ToTable("SalePayment", tb => tb.HasTrigger("TRG_SalePayment_Audit"));

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

            entity.ToTable("TableRestaurant", tb => tb.HasTrigger("TRG_TableRestaurant_Audit"));

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
