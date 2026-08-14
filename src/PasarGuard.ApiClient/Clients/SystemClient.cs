using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class SystemClient : ApiClientBase, ISystemClient
{
    public SystemClient(HttpClient httpClient, ILogger<SystemClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/api/inbounds", "get_inbounds")]
    public Task<ApiResult<IReadOnlyList<string>>> GetInboundsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/inbounds";
        var url = path;
        return SendAsync<IReadOnlyList<string>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/inbounds/details", "get_inbound_details")]
    public Task<ApiResult<IReadOnlyList<InboundSummary>>> GetInboundDetailsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/inbounds/details";
        var url = path;
        return SendAsync<IReadOnlyList<InboundSummary>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/system", "get_system_stats")]
    public Task<ApiResult<SystemStats>> GetSystemStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/system";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<SystemStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/system/resources", "get_system_resource_stats")]
    public Task<ApiResult<SystemResourceStats>> GetSystemResourceStatsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/system/resources";
        var url = path;
        return SendAsync<SystemResourceStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/system/users", "get_system_users_stats")]
    public Task<ApiResult<SystemUsersStats>> GetSystemUsersStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/system/users";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<SystemUsersStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/wireguard/subnets", "get_wireguard_subnets")]
    public Task<ApiResult<IReadOnlyList<WireGuardSubnetUsage>>> GetWireguardSubnetsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/wireguard/subnets";
        var url = path;
        return SendAsync<IReadOnlyList<WireGuardSubnetUsage>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/workers/health", "get_workers_health")]
    public Task<ApiResult<WorkersHealth>> GetWorkersHealthAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/workers/health";
        var url = path;
        return SendAsync<WorkersHealth>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
