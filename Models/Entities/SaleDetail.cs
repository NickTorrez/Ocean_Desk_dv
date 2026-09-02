using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class SaleDetail
{
    public int SaleDetailId { get; set; }

    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Discount { get; set; }

    public decimal Subtotal { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<KitchenOrderDetail> KitchenOrderDetails { get; set; } = new List<KitchenOrderDetail>();

    public virtual Sale Sale { get; set; } = null!;
}
