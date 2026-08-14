using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class DefaultClient : ApiClientBase, IDefaultClient
{
    public DefaultClient(HttpClient httpClient, ILogger<DefaultClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/", "base")]
    public Task<ApiResult<string>> BaseAsync(CancellationToken cancellationToken = default)
    {
        var path = "/";
        var url = path;
        return SendAsync<string>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/health", "health")]
    public Task<ApiResult<IReadOnlyDictionary<string, JsonElement>>> HealthAsync(CancellationToken cancellationToken = default)
    {
        var path = "/health";
        var url = path;
        return SendAsync<IReadOnlyDictionary<string, JsonElement>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
