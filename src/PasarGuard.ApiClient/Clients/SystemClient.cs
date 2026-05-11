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

public sealed class SystemClient : ApiClientBase, ISystemClient
{
    public SystemClient(HttpClient httpClient, ILogger<SystemClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<SystemStats>> GetSystemStatsAsync(string? adminUsername = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/system";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<SystemStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<string>>> GetInboundsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/inbounds";
        var url = path;
        return SendAsync<List<string>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<InboundSummary>>> GetInboundDetailsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/inbounds/details";
        var url = path;
        return SendAsync<List<InboundSummary>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<WorkersHealth>> GetWorkersHealthAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/workers/health";
        var url = path;
        return SendAsync<WorkersHealth>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
