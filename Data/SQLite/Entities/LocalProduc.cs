using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Data.SQLite.Entities
{
    /// <summary>
    /// Copia local de un producto procedente de SQL Server.
    /// Conserva el identificador original del servidor.
    /// </summary>
    public sealed class LocalProduct
    {
        public int ServerProductId { get; set; }

        public string ProductCode { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsActive { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public DateTime CachedAtUtc { get; set; }
    }
}
