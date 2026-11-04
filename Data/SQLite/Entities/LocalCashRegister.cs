using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Data.SQLite.Entities
{

    /// <summary>
    /// Representación local de una caja.
    /// Puede ser una copia de una caja existente en SQL Server
    /// o una caja provisional creada sin conexión.
    /// </summary>
    public sealed class LocalCashRegister
    {
        // Identificador generado exclusivamente en SQLite.
        public int LocalCashRegisterId { get; set; }

        // Identificador definitivo de SQL Server.
        // Permanece null mientras la caja sea provisional.
        public int? ServerCashRegisterId { get; set; }

        public int OpeningUserId { get; set; }

        public DateTime OpeningDateTime { get; set; }

        public decimal OpeningAmount { get; set; }

        public DateTime? ClosingDateTime { get; set; }

        public decimal? ExpectedCash { get; set; }

        public decimal? ActualCash { get; set; }

        public decimal? Difference { get; set; }

        public int? ClosingUserId { get; set; }

        public string Status { get; set; } = "Open";

        public LocalCashRegisterOrigin Origin { get; set; }

        public LocalCashSyncStatus SyncStatus { get; set; }

        public DateTime CachedAtUtc { get; set; }

        public DateTime? SynchronizedAtUtc { get; set; }

        public string? LastSyncError { get; set; }

        public ICollection<LocalCashMovement> Movements { get; set; }
            = new List<LocalCashMovement>();
    }

    /// <summary>
    /// Indica el origen de la representación local de la caja.
    /// </summary>
    public enum LocalCashRegisterOrigin
    {
        ServerCache = 0,
        OfflineCreated = 1
    }

    /// <summary>
    /// Estado de sincronización de la caja y sus movimientos.
    /// </summary>
    public enum LocalCashSyncStatus
    {
        Cached = 0,
        Pending = 1,
        Synchronized = 2,
        Conflict = 3,
        PermanentError = 4
    }

    /// <summary>
    /// Movimiento financiero conservado localmente.
    /// Puede representar ingresos, egresos o ventas.
    /// </summary>
    public sealed class LocalCashMovement
    {
        public int LocalCashMovementId { get; set; }

        public int LocalCashRegisterId { get; set; }

        public int? ServerCashMovementId { get; set; }

        public int UserId { get; set; }

        public string MovementType { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public string Concept { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime MovementDateTime { get; set; }

        public string? Reference { get; set; }

        public string? Notes { get; set; }

        public LocalCashSyncStatus SyncStatus { get; set; }

        public DateTime? SynchronizedAtUtc { get; set; }

        public string? LastSyncError { get; set; }
    }

}
