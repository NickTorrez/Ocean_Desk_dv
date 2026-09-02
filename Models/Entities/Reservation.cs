using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int CustomerId { get; set; }

    public int? TableId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public TimeOnly ReservationTime { get; set; }

    public byte GuestCount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime RegistrationDateTime { get; set; }

    public string? Notes { get; set; }

    public virtual TableRestaurant? Table { get; set; }
}
