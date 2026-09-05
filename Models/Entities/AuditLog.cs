using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class AuditLog
{
    public long AuditId { get; set; }

    public string TableName { get; set; } = null!;

    public string Operation { get; set; } = null!;

    public int? RecordId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string ChangedBy { get; set; } = null!;

    public DateTime ChangeDateTime { get; set; }
}
