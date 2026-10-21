using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class InventoryLot
{
    public long InventoryLotId { get; set; }

    public int ProductId { get; set; }

    public string? LotCode { get; set; }

    public DateTime ReceivedAt { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public decimal InitialQuantity { get; set; }

    public decimal RemainingQuantity { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    public virtual Product Product { get; set; } = null!;
}
