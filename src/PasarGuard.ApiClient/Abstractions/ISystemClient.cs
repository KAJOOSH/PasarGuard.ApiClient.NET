using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISystemClient
{
    [ApiEndpoint("GET", "/api/inbounds", "get_inbounds")]
    Task<ApiResult<IReadOnlyList<string>>> GetInboundsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/inbounds/details", "get_inbound_details")]
    Task<ApiResult<IReadOnlyList<InboundSummary>>> GetInboundDetailsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/system", "get_system_stats")]
    Task<ApiResult<SystemStats>> GetSystemStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/system/resources", "get_system_resource_stats")]
    Task<ApiResult<SystemResourceStats>> GetSystemResourceStatsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/system/users", "get_system_users_stats")]
    Task<ApiResult<SystemUsersStats>> GetSystemUsersStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/wireguard/subnets", "get_wireguard_subnets")]
    Task<ApiResult<IReadOnlyList<WireGuardSubnetUsage>>> GetWireguardSubnetsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/workers/health", "get_workers_health")]
    Task<ApiResult<WorkersHealth>> GetWorkersHealthAsync(CancellationToken cancellationToken = default);
}
