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

    public virtual DbSet<BitacoraCashMovement> BitacoraCashMovements { get; set; }

    public virtual DbSet<BitacoraGlobal> BitacoraGlobals { get; set; }

    public virtual DbSet<CashMovement> CashMovements { get; set; }

    public virtual DbSet<CashRegister> CashRegisters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryLot> InventoryLots { get; set; }

    public virtual DbSet<InventoryMovement> InventoryMovements { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<KitchenOrder> KitchenOrders { get; set; }

    public virtual DbSet<KitchenOrderDetail> KitchenOrderDetails { get; set; }

    public virtual DbSet<KitchenOrderHistory> KitchenOrderHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<SalePayment> SalePayments { get; set; }

    public virtual DbSet<TableRestaurant> TableRestaurants { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-444I7CB\\MSSQLSERVERSS;Database=Ocean_Desk_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__AuditLog__A17F239889F40EC3");

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

        modelBuilder.Entity<BitacoraCashMovement>(entity =>
        {
            entity.HasKey(e => e.BitacoraId);

            entity.ToTable("BitacoraCashMovement");

            entity.Property(e => e.ActionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("CashMovement");
        });

        modelBuilder.Entity<BitacoraGlobal>(entity =>
        {
            entity.HasKey(e => e.BitacoraId).HasName("PK__Bitacora__7ACF9B386D2CF83F");

            entity.ToTable("BitacoraGlobal");

            entity.Property(e => e.ActionType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CashMovement>(entity =>
        {
            entity.HasKey(e => e.CashMovementId).HasName("PK__CashMove__BB9938A6532B0A0D");

            entity.ToTable("CashMovement", tb =>
                {
                    tb.HasTrigger("TRG_Audit_CashMovement");
                    tb.HasTrigger("TRG_CashMovement_Audit");
                });

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
            entity.HasKey(e => e.CashRegisterId).HasName("PK__CashRegi__7B5CAE9460E38C5F");

            entity.ToTable("CashRegister", tb => tb.HasTrigger("TRG_CashRegister_Audit"));

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

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Inventory");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.CurrentStock).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.MinimumStock).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Product).WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Product");
        });

        modelBuilder.Entity<InventoryLot>(entity =>
        {
            entity.ToTable("InventoryLot");

            entity.HasIndex(e => e.ExpirationDate, "IX_InventoryLot_ExpirationDate").HasFilter("([ExpirationDate] IS NOT NULL)");

            entity.HasIndex(e => new { e.InventoryLotId, e.ProductId }, "UQ_InventoryLot_Id_ProductId").IsUnique();

            entity.HasIndex(e => new { e.ProductId, e.LotCode }, "UX_InventoryLot_Product_LotCode")
                .IsUnique()
                .HasFilter("([LotCode] IS NOT NULL)");

            entity.Property(e => e.InitialQuantity).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LotCode).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(250);
            entity.Property(e => e.ReceivedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.RemainingQuantity).HasColumnType("decimal(12, 4)");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryLots)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryLot_Product");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.ToTable("InventoryMovement");

            entity.HasIndex(e => new { e.ProductId, e.MovementDateTime }, "IX_InventoryMovement_Product_Date").IsDescending(false, true);

            entity.HasIndex(e => e.SaleId, "IX_InventoryMovement_SaleId").HasFilter("([SaleId] IS NOT NULL)");

            entity.Property(e => e.MovementDateTime)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.MovementType).HasMaxLength(20);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.ReferenceId).HasMaxLength(50);
            entity.Property(e => e.ReferenceType).HasMaxLength(30);
            entity.Property(e => e.StockAfter).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.StockBefore).HasColumnType("decimal(12, 4)");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryMovement_Product");

            entity.HasOne(d => d.Sale).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK_InventoryMovement_Sale");

            entity.HasOne(d => d.InventoryLot).WithMany(p => p.InventoryMovements)
                .HasPrincipalKey(p => new { p.InventoryLotId, p.ProductId })
                .HasForeignKey(d => new { d.InventoryLotId, d.ProductId })
                .HasConstraintName("FK_InventoryMovement_InventoryLot_Product");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB558B31AF1");

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
            entity.HasKey(e => e.KitchenOrderId).HasName("PK__KitchenO__4F08F985F46C78FC");

            entity.ToTable("KitchenOrder", tb => tb.HasTrigger("TRG_KitchenOrder_Audit"));

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
            entity.HasKey(e => e.KitchenOrderDetailId).HasName("PK__KitchenO__C2B2DB19E949AAC7");

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
            entity.HasKey(e => e.KitchenOrderHistoryId).HasName("PK__KitchenO__B3F438967997B6AA");

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

            entity.HasOne(d => d.User).WithMany(p => p.KitchenOrderHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_History_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCategoryId, "IX_Product_ProductCategoryId");

            entity.HasIndex(e => e.ProductName, "IX_Product_ProductName");

            entity.HasIndex(e => new { e.ProductType, e.IsActive }, "IX_Product_ProductType_IsActive");

            entity.HasIndex(e => e.ProductCode, "UQ_Product_ProductCode").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.ProductCode).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(150);
            entity.Property(e => e.ProductType)
                .HasMaxLength(20)
                .HasDefaultValue("FinishedProduct");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");

            entity.HasOne(d => d.UnitOfMeasure).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitOfMeasureId)
                .HasConstraintName("FK_Product_UnitOfMeasure");
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

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("Recipe");

            entity.HasIndex(e => e.ProductId, "UQ_Recipe_ProductId").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Instructions).HasMaxLength(1000);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);

            entity.HasOne(d => d.Product).WithOne(p => p.Recipe)
                .HasForeignKey<Recipe>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_Product");
        });

        modelBuilder.Entity<RecipeDetail>(entity =>
        {
            entity.ToTable("RecipeDetail");

            entity.HasIndex(e => e.IngredientProductId, "IX_RecipeDetail_IngredientProductId");

            entity.HasIndex(e => new { e.RecipeId, e.IngredientProductId }, "UQ_RecipeDetail_Recipe_Ingredient").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Notes).HasMaxLength(250);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 4)");

            entity.HasOne(d => d.IngredientProduct).WithMany(p => p.RecipeDetails)
                .HasForeignKey(d => d.IngredientProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeDetail_IngredientProduct");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeDetails)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeDetail_Recipe");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F247B8B9590");

            entity.ToTable("Reservation", tb => tb.HasTrigger("TRG_Reservation_Audit"));

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

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleCode, "UQ_Role_RoleCode").IsUnique();

            entity.HasIndex(e => e.RoleName, "UQ_Role_RoleName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RoleName).HasMaxLength(80);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FF6F479B23");

            entity.ToTable("Sale", tb =>
                {
                    tb.HasTrigger("TRG_Audit_Sale");
                    tb.HasTrigger("TRG_Sale_Audit");
                });

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

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_User");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FEE505BCEA");

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
            entity.HasKey(e => e.SalePaymentId).HasName("PK__SalePaym__C5E7A5451D8D2084");

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
            entity.HasKey(e => e.TableId).HasName("PK__TableRes__7D5F01EE9662828A");

            entity.ToTable("TableRestaurant", tb => tb.HasTrigger("TRG_TableRestaurant_Audit"));

            entity.HasIndex(e => e.TableNumber, "UQ_TableRestaurant_Number").IsUnique();

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(300);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Available");
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.ToTable("UnitOfMeasure");

            entity.HasIndex(e => e.UnitCode, "UQ_UnitOfMeasure_UnitCode").IsUnique();

            entity.HasIndex(e => e.UnitName, "UQ_UnitOfMeasure_UnitName").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UnitCode).HasMaxLength(20);
            entity.Property(e => e.UnitName).HasMaxLength(50);
            entity.Property(e => e.UnitSymbol).HasMaxLength(10);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.IsActive, "IX_User_IsActive");

            entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

            entity.HasIndex(e => e.Username, "UQ_User_Username").IsUnique();

            entity.HasIndex(e => e.Email, "UX_User_Email")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(80);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLoginAt).HasPrecision(0);
            entity.Property(e => e.LastName).HasMaxLength(80);
            entity.Property(e => e.PasswordChangedAt).HasPrecision(0);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasPrecision(0);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
