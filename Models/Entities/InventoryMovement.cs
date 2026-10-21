using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class InventoryMovement
{
    public long InventoryMovementId { get; set; }

    public int ProductId { get; set; }

    public string MovementType { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal StockBefore { get; set; }

    public decimal StockAfter { get; set; }

    public int? SaleId { get; set; }

    public string? ReferenceType { get; set; }

    public string? ReferenceId { get; set; }

    public string? Notes { get; set; }

    public DateTime MovementDateTime { get; set; }

    public long? InventoryLotId { get; set; }

    public virtual InventoryLot? InventoryLot { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale? Sale { get; set; }
}
