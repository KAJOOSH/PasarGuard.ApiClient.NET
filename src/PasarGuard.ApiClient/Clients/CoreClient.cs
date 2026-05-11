using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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

    public Task<ApiResult<CoreResponse>> CreateCoreConfigAsync(CoreCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/core";
        var url = path;
        return SendAsync<CoreResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<CoreResponse>> GetCoreConfigAsync(long coreId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var url = path;
        return SendAsync<CoreResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<CoreResponse>> ModifyCoreConfigAsync(long coreId, bool restartNodes, CoreCreate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var query = new QueryStringBuilder()
            .Add(@"restart_nodes", restartNodes);
        var url = query.Build(path);
        return SendAsync<CoreResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> DeleteCoreConfigAsync(long coreId, bool? restartNodes = false, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/core/{UrlEncoding.EncodePathSegment(coreId)}";
        var query = new QueryStringBuilder()
            .Add(@"restart_nodes", restartNodes);
        var url = query.Build(path);
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<CoreResponseList>> GetAllCoresAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/cores";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<CoreResponseList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<CoresSimpleResponse>> GetCoresSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/cores/simple";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"search", search)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<CoresSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult> RestartCoreAsync(long coreId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/core/{UrlEncoding.EncodePathSegment(coreId)}/restart";
        var url = path;
        return SendAsync(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveCoresResponse>> BulkDeleteCoresAsync(BulkCoreSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/cores/bulk/delete";
        var url = path;
        return SendAsync<RemoveCoresResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
