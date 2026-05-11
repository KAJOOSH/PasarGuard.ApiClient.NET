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

public sealed class DefaultClient : ApiClientBase, IDefaultClient
{
    public DefaultClient(HttpClient httpClient, ILogger<DefaultClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<string>> BaseAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/";
        var url = path;
        return SendAsync<string>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<Dictionary<string, object?>>> HealthAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/health";
        var url = path;
        return SendAsync<Dictionary<string, object?>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
