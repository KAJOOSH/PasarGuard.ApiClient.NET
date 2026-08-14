using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class SetupClient : ApiClientBase, ISetupClient
{
    public SetupClient(HttpClient httpClient, ILogger<SetupClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("DELETE", "/api/setup/owner", "delete_owner")]
    public Task<ApiResult> DeleteOwnerAsync(string key, CancellationToken cancellationToken = default)
    {
        var path = "/api/setup/owner";
        var query = new QueryStringBuilder()
            .Add("key", key);
        var url = query.Build(path);
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PATCH", "/api/setup/owner", "reset_owner_password")]
    public Task<ApiResult<AdminDetails>> ResetOwnerPasswordAsync(OwnerResetRequest request, CancellationToken cancellationToken = default)
    {
        var path = "/api/setup/owner";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Patch, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/setup/owner", "create_owner")]
    public Task<ApiResult<AdminDetails>> CreateOwnerAsync(OwnerCreateRequest request, CancellationToken cancellationToken = default)
    {
        var path = "/api/setup/owner";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/setup/owner/upgrade", "upgrade_owner")]
    public Task<ApiResult<AdminDetails>> UpgradeOwnerAsync(OwnerUpgradeRequest request, CancellationToken cancellationToken = default)
    {
        var path = "/api/setup/owner/upgrade";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
