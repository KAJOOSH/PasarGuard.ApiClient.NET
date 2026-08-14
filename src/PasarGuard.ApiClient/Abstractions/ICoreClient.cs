using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ICoreClient
{
    [ApiEndpoint("POST", "/api/core", "create_core_config")]
    Task<ApiResult<CoreResponse>> CreateCoreConfigAsync(CoreCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/core/reality-scan", "scan_reality_target")]
    Task<ApiResult<RealityScanResult>> ScanRealityTargetAsync(RealityScanRequest request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/core/{core_id}", "delete_core_config")]
    Task<ApiResult> DeleteCoreConfigAsync(long coreId, bool restartNodes = false, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/core/{core_id}", "get_core_config")]
    Task<ApiResult<CoreResponse>> GetCoreConfigAsync(long coreId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/core/{core_id}", "modify_core_config")]
    Task<ApiResult<CoreResponse>> ModifyCoreConfigAsync(long coreId, bool restartNodes, CoreCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/core/{core_id}/restart", "restart_core")]
    Task<ApiResult> RestartCoreAsync(long coreId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/cores", "get_all_cores")]
    Task<ApiResult<CoreResponseList>> GetAllCoresAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/cores/bulk/delete", "bulk_delete_cores")]
    Task<ApiResult<RemoveCoresResponse>> BulkDeleteCoresAsync(BulkCoreSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/cores/simple", "get_cores_simple")]
    Task<ApiResult<CoresSimpleResponse>> GetCoresSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
