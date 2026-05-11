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

public sealed class SubscriptionClient : ApiClientBase, ISubscriptionClient
{
    public SubscriptionClient(HttpClient httpClient, ILogger<SubscriptionClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<JsonElement>> UserSubscriptionAsync(string token, string? userAgent = @"", CancellationToken cancellationToken = default)
    {
        var path = $@"/sub/{UrlEncoding.EncodePathSegment(token)}/";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            [@"user-agent"] = ValueFormatter.FormatNullable(userAgent)
        };
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, headers, cancellationToken);
    }

    public Task<ApiResult<SubscriptionUserResponse>> UserSubscriptionInfoAsync(string token, CancellationToken cancellationToken = default)
    {
        var path = $@"/sub/{UrlEncoding.EncodePathSegment(token)}/info";
        var url = path;
        return SendAsync<SubscriptionUserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<ApplicationOutput>>> UserSubscriptionAppsAsync(string token, CancellationToken cancellationToken = default)
    {
        var path = $@"/sub/{UrlEncoding.EncodePathSegment(token)}/apps";
        var url = path;
        return SendAsync<List<ApplicationOutput>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetSubUserUsageAsync(string token, DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, CancellationToken cancellationToken = default)
    {
        var path = $@"/sub/{UrlEncoding.EncodePathSegment(token)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"start", start)
            .Add(@"end", end)
            .Add(@"period", period);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> UserSubscriptionWithClientTypeAsync(string token, ConfigFormat clientType, CancellationToken cancellationToken = default)
    {
        var path = $@"/sub/{UrlEncoding.EncodePathSegment(token)}/{UrlEncoding.EncodePathSegment(clientType)}";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
