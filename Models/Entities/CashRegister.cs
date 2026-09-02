using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class CashRegister
{
    public int CashRegisterId { get; set; }

    public int OpeningUserId { get; set; }

    public DateTime OpeningDateTime { get; set; }

    public decimal OpeningAmount { get; set; }

    public DateTime? ClosingDateTime { get; set; }

    public decimal? ExpectedCash { get; set; }

    public decimal? ActualCash { get; set; }

    public decimal? Difference { get; set; }

    public int? ClosingUserId { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<CashMovement> CashMovements { get; set; } = new List<CashMovement>();
}
