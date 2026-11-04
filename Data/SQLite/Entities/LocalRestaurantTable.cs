using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Data.SQLite.Entities
{
    /// <summary>
    /// Copia local de una mesa del restaurante.
    /// Conserva el identificador original de SQL Server.
    /// </summary>
    public sealed class LocalRestaurantTable
    {
        public int ServerTableId { get; set; }

        public int TableNumber { get; set; }

        public byte Capacity { get; set; }

        public string Status { get; set; } = "Available";

        public bool IsActive { get; set; }

        public DateTime CachedAtUtc { get; set; }
    }
}
