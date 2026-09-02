using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int SaleId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateTime IssueDateTime { get; set; }

    public int? CustomerId { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CancellationDateTime { get; set; }

    public string? CancellationReason { get; set; }

    public int? CancellationUserId { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}
