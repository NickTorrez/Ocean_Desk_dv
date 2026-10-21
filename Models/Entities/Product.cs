using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int ProductCategoryId { get; set; }

    public decimal UnitPrice { get; set; }

    public bool IsAvailable { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string ProductType { get; set; } = null!;

    public int? UnitOfMeasureId { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ICollection<InventoryLot> InventoryLots { get; set; } = new List<InventoryLot>();

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual Recipe? Recipe { get; set; }

    public virtual ICollection<RecipeDetail> RecipeDetails { get; set; } = new List<RecipeDetail>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual UnitOfMeasure? UnitOfMeasure { get; set; }
}
