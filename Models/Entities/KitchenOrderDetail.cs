using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class KitchenOrderDetail
{
    public int KitchenOrderDetailId { get; set; }

    public int KitchenOrderId { get; set; }

    public int SaleDetailId { get; set; }

    public int ProductId { get; set; }

    public decimal Quantity { get; set; }

    public string? Notes { get; set; }

    public virtual KitchenOrder KitchenOrder { get; set; } = null!;

    public virtual SaleDetail SaleDetail { get; set; } = null!;
}
