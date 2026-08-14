using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IUserHwidClient
{
    [ApiEndpoint("GET", "/api/user/{user_id}/hwids", "get_user_hwids")]
    Task<ApiResult<UserHWIDListResponse>> GetUserHwidsAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/{user_id}/hwids/reset", "reset_user_hwids")]
    Task<ApiResult<JsonElement>> ResetUserHwidsAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/user/{user_id}/hwids/{hwid}", "delete_user_hwid")]
    Task<ApiResult<JsonElement>> DeleteUserHwidAsync(long userId, string hwid, CancellationToken cancellationToken = default);
}
