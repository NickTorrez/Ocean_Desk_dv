using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class CashMovement
{
    public int CashMovementId { get; set; }

    public int CashRegisterId { get; set; }

    public int? SaleId { get; set; }

    public int UserId { get; set; }

    public string MovementType { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public string Concept { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime MovementDateTime { get; set; }

    public string? Reference { get; set; }

    public string? Notes { get; set; }

    public virtual CashRegister CashRegister { get; set; } = null!;

    public virtual Sale? Sale { get; set; }
}
