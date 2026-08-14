using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class SettingsClient : ApiClientBase, ISettingsClient
{
    public SettingsClient(HttpClient httpClient, ILogger<SettingsClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/api/settings", "get_settings")]
    public Task<ApiResult<SettingsSchema>> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/settings";
        var url = path;
        return SendAsync<SettingsSchema>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/settings", "modify_settings")]
    public Task<ApiResult<SettingsSchema>> ModifySettingsAsync(SettingsSchema request, CancellationToken cancellationToken = default)
    {
        var path = "/api/settings";
        var url = path;
        return SendAsync<SettingsSchema>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/settings/general", "get_general_settings")]
    public Task<ApiResult<General>> GetGeneralSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/settings/general";
        var url = path;
        return SendAsync<General>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
