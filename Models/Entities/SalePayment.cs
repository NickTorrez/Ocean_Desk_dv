using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class SalePayment
{
    public int SalePaymentId { get; set; }

    public int SaleId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? Reference { get; set; }

    public DateTime PaymentDateTime { get; set; }

    public string? Notes { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
