using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class UserHwidClient : ApiClientBase, IUserHwidClient
{
    public UserHwidClient(HttpClient httpClient, ILogger<UserHwidClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/api/user/{user_id}/hwids", "get_user_hwids")]
    public Task<ApiResult<UserHWIDListResponse>> GetUserHwidsAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(userId)}/hwids";
        var url = path;
        return SendAsync<UserHWIDListResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/{user_id}/hwids/reset", "reset_user_hwids")]
    public Task<ApiResult<JsonElement>> ResetUserHwidsAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(userId)}/hwids/reset";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/user/{user_id}/hwids/{hwid}", "delete_user_hwid")]
    public Task<ApiResult<JsonElement>> DeleteUserHwidAsync(long userId, string hwid, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(userId)}/hwids/{UrlEncoding.EncodePathSegment(hwid)}";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
