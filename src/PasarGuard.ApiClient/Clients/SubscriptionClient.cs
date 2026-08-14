using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class SubscriptionClient : ApiClientBase, ISubscriptionClient
{
    public SubscriptionClient(HttpClient httpClient, ILogger<SubscriptionClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/sub/{token}/", "user_subscription")]
    public Task<ApiResult<string>> UserSubscriptionAsync(string token, string userAgent = "", string? xHwid = null, string? xDeviceOs = null, string? xVerOs = null, string? xDeviceModel = null, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            ["user-agent"] = ValueFormatter.FormatNullable(userAgent),
            ["X-HWID"] = ValueFormatter.FormatNullable(xHwid),
            ["X-Device-OS"] = ValueFormatter.FormatNullable(xDeviceOs),
            ["X-Ver-OS"] = ValueFormatter.FormatNullable(xVerOs),
            ["X-Device-Model"] = ValueFormatter.FormatNullable(xDeviceModel)
        };
        return SendAsync<string>(HttpMethod.Get, url, null, RequestBodyKind.None, headers, cancellationToken);
    }

    [ApiEndpoint("HEAD", "/sub/{token}/", "user_subscription_headers")]
    public Task<ApiResult> UserSubscriptionHeadersAsync(string token, string userAgent = "", CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            ["user-agent"] = ValueFormatter.FormatNullable(userAgent)
        };
        return SendAsync(HttpMethod.Head, url, null, RequestBodyKind.None, headers, cancellationToken);
    }

    [ApiEndpoint("GET", "/sub/{token}/apps", "user_subscription_apps")]
    public Task<ApiResult<IReadOnlyList<Application>>> UserSubscriptionAppsAsync(string token, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/apps";
        var url = path;
        return SendAsync<IReadOnlyList<Application>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/sub/{token}/info", "user_subscription_info")]
    public Task<ApiResult<SubscriptionUserResponse>> UserSubscriptionInfoAsync(string token, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/info";
        var url = path;
        return SendAsync<SubscriptionUserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/sub/{token}/raw", "user_subscription_raw")]
    public Task<ApiResult<string>> UserSubscriptionRawAsync(string token, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/raw";
        var url = path;
        return SendAsync<string>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/sub/{token}/usage", "get_sub_user_usage")]
    public Task<ApiResult<UserUsageStatsList>> GetSubUserUsageAsync(string token, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/sub/{token}/{client_type}", "user_subscription_with_client_type")]
    public Task<ApiResult<string>> UserSubscriptionWithClientTypeAsync(string token, ConfigFormat clientType, string? xHwid = null, string? xDeviceOs = null, string? xVerOs = null, string? xDeviceModel = null, CancellationToken cancellationToken = default)
    {
        var path = $"/sub/{UrlEncoding.EncodePathSegment(token)}/{UrlEncoding.EncodePathSegment(clientType)}";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            ["X-HWID"] = ValueFormatter.FormatNullable(xHwid),
            ["X-Device-OS"] = ValueFormatter.FormatNullable(xDeviceOs),
            ["X-Ver-OS"] = ValueFormatter.FormatNullable(xVerOs),
            ["X-Device-Model"] = ValueFormatter.FormatNullable(xDeviceModel)
        };
        return SendAsync<string>(HttpMethod.Get, url, null, RequestBodyKind.None, headers, cancellationToken);
    }
}
