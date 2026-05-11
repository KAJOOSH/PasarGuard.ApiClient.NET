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

public sealed class SettingsClient : ApiClientBase, ISettingsClient
{
    public SettingsClient(HttpClient httpClient, ILogger<SettingsClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<SettingsSchemaOutput>> GetSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/settings";
        var url = path;
        return SendAsync<SettingsSchemaOutput>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<SettingsSchemaOutput>> ModifySettingsAsync(SettingsSchemaInput request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/settings";
        var url = path;
        return SendAsync<SettingsSchemaOutput>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<General>> GetGeneralSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/settings/general";
        var url = path;
        return SendAsync<General>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
