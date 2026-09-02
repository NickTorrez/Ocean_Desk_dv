using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class KitchenOrderHistory
{
    public int KitchenOrderHistoryId { get; set; }

    public int KitchenOrderId { get; set; }

    public string? PreviousStatus { get; set; }

    public string NewStatus { get; set; } = null!;

    public int? UserId { get; set; }

    public DateTime ChangeDateTime { get; set; }

    public string? Notes { get; set; }

    public virtual KitchenOrder KitchenOrder { get; set; } = null!;
}
