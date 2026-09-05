using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class TableRestaurant
{
    public int TableId { get; set; }

    public int TableNumber { get; set; }

    public byte Capacity { get; set; }

    public string Status { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
