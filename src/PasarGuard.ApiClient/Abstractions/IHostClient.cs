using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IHostClient
{
    Task<ApiResult<BaseHost>> GetHostAsync(long hostId, CancellationToken cancellationToken = default);

    Task<ApiResult<BaseHost>> ModifyHostAsync(long hostId, CreateHost request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveHostAsync(long hostId, CancellationToken cancellationToken = default);

    Task<ApiResult<List<BaseHost>>> GetHostsAsync(long? offset = 0L, long? limit = 0L, CancellationToken cancellationToken = default);

    Task<ApiResult<List<BaseHost>>> ModifyHostsAsync(List<CreateHost> request, CancellationToken cancellationToken = default);

    Task<ApiResult<BaseHost>> CreateHostAsync(CreateHost request, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveHostsResponse>> BulkDeleteHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkHostsActionResponse>> BulkDisableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkHostsActionResponse>> BulkEnableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default);
}
