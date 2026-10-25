using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }

    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitCost { get; set; }

    public decimal Subtotal { get; set; }

    public decimal ReceivedQuantity { get; set; }

    public string? LotCode { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? Notes { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
