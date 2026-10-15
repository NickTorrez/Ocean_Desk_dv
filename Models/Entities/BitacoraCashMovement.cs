using System;
using System.Collections.Generic;

namespace Ocean_Desk_dv.Models.Entities;

public partial class BitacoraCashMovement
{
    public int BitacoraId { get; set; }

    public string TableName { get; set; } = null!;

    public string ActionType { get; set; } = null!;

    public DateTime ChangeDate { get; set; }

    public string Description { get; set; } = null!;
}
