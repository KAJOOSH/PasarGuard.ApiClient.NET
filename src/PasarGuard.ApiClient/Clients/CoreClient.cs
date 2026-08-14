using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class CoreClient : ApiClientBase, ICoreClient
{
    public CoreClient(HttpClient httpClient, ILogger<CoreClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/core", "create_core_config")]
    public Task<ApiResult<CoreResponse>> CreateCoreConfigAsync(CoreCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/core";
        var url = path;
        return SendAsync<CoreResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/core/reality-scan", "scan_reality_target")]
    public Task<ApiResult<RealityScanResult>> ScanRealityTargetAsync(RealityScanRequest request, CancellationToken cancellationToken = default)
    {
        var path = "/api/core/reality-scan";
        var url = path;
        return SendAsync<RealityScanResult>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/core/{core_id}", "delete_core_config")]
    public Task<ApiResult> DeleteCoreConfigAsync(long coreId, bool restartNodes = false, CancellationToken cancellationToken = default)
    {
        var path = $"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var query = new QueryStringBuilder()
            .Add("restart_nodes", restartNodes);
        var url = query.Build(path);
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/core/{core_id}", "get_core_config")]
    public Task<ApiResult<CoreResponse>> GetCoreConfigAsync(long coreId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var url = path;
        return SendAsync<CoreResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/core/{core_id}", "modify_core_config")]
    public Task<ApiResult<CoreResponse>> ModifyCoreConfigAsync(long coreId, bool restartNodes, CoreCreate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var query = new QueryStringBuilder()
            .Add("restart_nodes", restartNodes);
        var url = query.Build(path);
        return SendAsync<CoreResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/core/{core_id}/restart", "restart_core")]
    public Task<ApiResult> RestartCoreAsync(long coreId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/core/{UrlEncoding.EncodePathSegment(coreId)}/restart";
        var url = path;
        return SendAsync(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/cores", "get_all_cores")]
    public Task<ApiResult<CoreResponseList>> GetAllCoresAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/cores";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<CoreResponseList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/cores/bulk/delete", "bulk_delete_cores")]
    public Task<ApiResult<RemoveCoresResponse>> BulkDeleteCoresAsync(BulkCoreSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/cores/bulk/delete";
        var url = path;
        return SendAsync<RemoveCoresResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/cores/simple", "get_cores_simple")]
    public Task<ApiResult<CoresSimpleResponse>> GetCoresSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/cores/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<CoresSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
