using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class KitchenOrder
{
    public int KitchenOrderId { get; set; }

    public int SaleId { get; set; }

    public DateTime ReceptionDateTime { get; set; }

    public DateTime? PreparationStartDateTime { get; set; }

    public DateTime? ReadyDateTime { get; set; }

    public DateTime? DeliveredDateTime { get; set; }

    public string Status { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<KitchenOrderDetail> KitchenOrderDetails { get; set; } = new List<KitchenOrderDetail>();

    public virtual ICollection<KitchenOrderHistory> KitchenOrderHistories { get; set; } = new List<KitchenOrderHistory>();

    public virtual Sale Sale { get; set; } = null!;
}
