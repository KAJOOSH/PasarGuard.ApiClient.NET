using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface ISubscriptionClient
{
    [ApiEndpoint("GET", "/sub/{token}/", "user_subscription")]
    Task<ApiResult<string>> UserSubscriptionAsync(string token, string userAgent = "", string? xHwid = null, string? xDeviceOs = null, string? xVerOs = null, string? xDeviceModel = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("HEAD", "/sub/{token}/", "user_subscription_headers")]
    Task<ApiResult> UserSubscriptionHeadersAsync(string token, string userAgent = "", CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/sub/{token}/apps", "user_subscription_apps")]
    Task<ApiResult<IReadOnlyList<Application>>> UserSubscriptionAppsAsync(string token, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/sub/{token}/info", "user_subscription_info")]
    Task<ApiResult<SubscriptionUserResponse>> UserSubscriptionInfoAsync(string token, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/sub/{token}/raw", "user_subscription_raw")]
    Task<ApiResult<string>> UserSubscriptionRawAsync(string token, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/sub/{token}/usage", "get_sub_user_usage")]
    Task<ApiResult<UserUsageStatsList>> GetSubUserUsageAsync(string token, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/sub/{token}/{client_type}", "user_subscription_with_client_type")]
    Task<ApiResult<string>> UserSubscriptionWithClientTypeAsync(string token, ConfigFormat clientType, string? xHwid = null, string? xDeviceOs = null, string? xVerOs = null, string? xDeviceModel = null, CancellationToken cancellationToken = default);
}
