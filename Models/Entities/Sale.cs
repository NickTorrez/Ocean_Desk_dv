using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime SaleDateTime { get; set; }

    public int UserId { get; set; }

    public int? CustomerId { get; set; }

    public string OrderType { get; set; } = null!;

    public int? TableId { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<CashMovement> CashMovements { get; set; } = new List<CashMovement>();

    public virtual Invoice? Invoice { get; set; }

    public virtual KitchenOrder? KitchenOrder { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<SalePayment> SalePayments { get; set; } = new List<SalePayment>();
}
