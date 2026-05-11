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

public sealed class HostClient : ApiClientBase, IHostClient
{
    public HostClient(HttpClient httpClient, ILogger<HostClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<BaseHost>> GetHostAsync(long hostId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<BaseHost>> ModifyHostAsync(long hostId, CreateHost request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveHostAsync(long hostId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<BaseHost>>> GetHostsAsync(long? offset = 0L, long? limit = 0L, CancellationToken cancellationToken = default)
    {
        var path = @"/api/hosts";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<List<BaseHost>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<BaseHost>>> ModifyHostsAsync(List<CreateHost> request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/hosts";
        var url = path;
        return SendAsync<List<BaseHost>>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BaseHost>> CreateHostAsync(CreateHost request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/host/";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<RemoveHostsResponse>> BulkDeleteHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/hosts/bulk/delete";
        var url = path;
        return SendAsync<RemoveHostsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkHostsActionResponse>> BulkDisableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/hosts/bulk/disable";
        var url = path;
        return SendAsync<BulkHostsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkHostsActionResponse>> BulkEnableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/hosts/bulk/enable";
        var url = path;
        return SendAsync<BulkHostsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
