using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public string PurchaseCode { get; set; } = null!;

    public int SupplierId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public string? DocumentNumber { get; set; }

    public string Status { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Total { get; set; }

    public string? Notes { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
