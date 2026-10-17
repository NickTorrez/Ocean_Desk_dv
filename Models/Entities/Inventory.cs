using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Inventory
{
    public int ProductId { get; set; }

    public decimal CurrentStock { get; set; }

    public decimal MinimumStock { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
