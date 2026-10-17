using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class UnitOfMeasure
{
    public int UnitOfMeasureId { get; set; }

    public string UnitCode { get; set; } = null!;

    public string UnitName { get; set; } = null!;

    public string UnitSymbol { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
