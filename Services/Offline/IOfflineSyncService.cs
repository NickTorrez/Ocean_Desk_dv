using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Services.Offline;

public interface IOfflineSyncService : IDisposable
{
    Task<OfflineSyncResult> SincronizarPendientesAsync(
        CancellationToken cancellationToken = default);
}
