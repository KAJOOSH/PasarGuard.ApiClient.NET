using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ICoreClient
{
    Task<ApiResult<CoreResponse>> CreateCoreConfigAsync(CoreCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<CoreResponse>> GetCoreConfigAsync(long coreId, CancellationToken cancellationToken = default);

    Task<ApiResult<CoreResponse>> ModifyCoreConfigAsync(long coreId, bool restartNodes, CoreCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult> DeleteCoreConfigAsync(long coreId, bool? restartNodes = false, CancellationToken cancellationToken = default);

    Task<ApiResult<CoreResponseList>> GetAllCoresAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    Task<ApiResult<CoresSimpleResponse>> GetCoresSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult> RestartCoreAsync(long coreId, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveCoresResponse>> BulkDeleteCoresAsync(BulkCoreSelection request, CancellationToken cancellationToken = default);
}
