using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class RoleModulePermission
{
    public int RoleModulePermissionId { get; set; }

    public int RoleId { get; set; }

    public string ModuleCode { get; set; } = null!;

    public bool CanView { get; set; }

    public bool CanCreate { get; set; }

    public bool CanEdit { get; set; }

    public bool CanDelete { get; set; }

    public bool CanExport { get; set; }

    public bool CanChangeStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Role Role { get; set; } = null!;
}
