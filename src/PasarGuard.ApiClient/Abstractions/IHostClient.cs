using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IHostClient
{
    [ApiEndpoint("POST", "/api/host/", "create_host")]
    Task<ApiResult<BaseHost>> CreateHostAsync(CreateHost request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/host/{host_id}", "remove_host")]
    Task<ApiResult> RemoveHostAsync(long hostId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/host/{host_id}", "get_host")]
    Task<ApiResult<BaseHost>> GetHostAsync(long hostId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/host/{host_id}", "modify_host")]
    Task<ApiResult<BaseHost>> ModifyHostAsync(long hostId, CreateHost request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/hosts", "get_hosts")]
    Task<ApiResult<IReadOnlyList<BaseHost>>> GetHostsAsync(IReadOnlyList<long>? ids = null, long offset = 0L, long limit = 0L, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/hosts", "modify_hosts")]
    Task<ApiResult<IReadOnlyList<BaseHost>>> ModifyHostsAsync(IReadOnlyList<CreateHost> request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/hosts/bulk/delete", "bulk_delete_hosts")]
    Task<ApiResult<RemoveHostsResponse>> BulkDeleteHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/hosts/bulk/disable", "bulk_disable_hosts")]
    Task<ApiResult<BulkHostsActionResponse>> BulkDisableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/hosts/bulk/enable", "bulk_enable_hosts")]
    Task<ApiResult<BulkHostsActionResponse>> BulkEnableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);
}
