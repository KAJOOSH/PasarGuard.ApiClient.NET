using System.Text.Json;
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

    [ApiEndpoint("POST", "/api/host/", "create_host")]
    public Task<ApiResult<BaseHost>> CreateHostAsync(CreateHost request, CancellationToken cancellationToken = default)
    {
        var path = "/api/host/";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/host/{host_id}", "remove_host")]
    public Task<ApiResult> RemoveHostAsync(long hostId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/host/{host_id}", "get_host")]
    public Task<ApiResult<BaseHost>> GetHostAsync(long hostId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/host/{host_id}", "modify_host")]
    public Task<ApiResult<BaseHost>> ModifyHostAsync(long hostId, CreateHost request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/host/{UrlEncoding.EncodePathSegment(hostId)}";
        var url = path;
        return SendAsync<BaseHost>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/hosts", "get_hosts")]
    public Task<ApiResult<IReadOnlyList<BaseHost>>> GetHostsAsync(IReadOnlyList<long>? ids = null, long offset = 0L, long limit = 0L, CancellationToken cancellationToken = default)
    {
        var path = "/api/hosts";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<IReadOnlyList<BaseHost>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/hosts", "modify_hosts")]
    public Task<ApiResult<IReadOnlyList<BaseHost>>> ModifyHostsAsync(IReadOnlyList<CreateHost> request, CancellationToken cancellationToken = default)
    {
        var path = "/api/hosts";
        var url = path;
        return SendAsync<IReadOnlyList<BaseHost>>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/hosts/bulk/delete", "bulk_delete_hosts")]
    public Task<ApiResult<RemoveHostsResponse>> BulkDeleteHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/hosts/bulk/delete";
        var url = path;
        return SendAsync<RemoveHostsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/hosts/bulk/disable", "bulk_disable_hosts")]
    public Task<ApiResult<BulkHostsActionResponse>> BulkDisableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/hosts/bulk/disable";
        var url = path;
        return SendAsync<BulkHostsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/hosts/bulk/enable", "bulk_enable_hosts")]
    public Task<ApiResult<BulkHostsActionResponse>> BulkEnableHostsAsync(BulkHostSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/hosts/bulk/enable";
        var url = path;
        return SendAsync<BulkHostsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
