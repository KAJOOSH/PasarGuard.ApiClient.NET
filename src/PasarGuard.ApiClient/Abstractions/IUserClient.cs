using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;
using System.Text.Json;

namespace PasarGuard.ApiClient.Abstractions;

public interface IUserClient
{
    Task<ApiResult<UserResponse>> CreateUserAsync(UserCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserAsync(string username, UserModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveUserAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> GetUserAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserByUsernameAsync(string username, UserModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserByIdAsync(long userId, UserModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveUserByIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> GetUserByIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ResetUserDataUsageAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ResetUserDataUsageByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ResetUserDataUsageByIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> RevokeUserSubscriptionAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> RevokeUserSubscriptionByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> RevokeUserSubscriptionByIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ResetUsersDataUsageAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<UserSubscriptionUpdateChart>> GetUsersSubUpdateChartAsync(long? userId = null, string? username = null, long? adminId = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> SetOwnerAsync(string username, string adminUsername, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> SetOwnerByUsernameAsync(string username, string adminUsername, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> SetOwnerByIdAsync(long userId, string adminUsername, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ActiveNextPlanAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ActiveNextPlanByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ActiveNextPlanByIdAsync(long userId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> GetUserSubscriptionByIdAsync(long userId, ConfigFormat clientType, CancellationToken cancellationToken = default);

    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListAsync(string username, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default);

    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByUsernameAsync(string username, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default);

    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByIdAsync(long userId, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default);

    Task<ApiResult<UsersResponse>> GetUsersAsync(long? offset = null, long? limit = null, IEnumerable<string>? username = null, IEnumerable<string>? admin = null, IEnumerable<long>? group = null, string? search = null, UserStatus? status = null, string? sort = null, string? proxyId = null, bool? loadSub = false, CancellationToken cancellationToken = default);

    Task<ApiResult<UsersSimpleResponse>> GetUsersSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetUserUsageAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetUserUsageByUsernameAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetUserUsageByIdAsync(long userId, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<UserUsageStatsList>> GetUsersUsageAsync(Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IEnumerable<string>? admin = null, CancellationToken cancellationToken = default);

    Task<ApiResult<List<string>>> GetExpiredUsersAsync(string? adminUsername = null, string? target = @"expired", DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveUsersResponse>> DeleteExpiredUsersAsync(string? adminUsername = null, string? target = @"expired", DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveUsersResponse>> BulkDeleteUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkResetUsersDataUsageAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkDisableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkEnableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkRevokeUsersSubscriptionAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkSetOwnerAsync(BulkUsersSetOwner request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> CreateUserFromTemplateAsync(CreateUserFromTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersCreateResponse>> BulkCreateUsersFromTemplateAsync(BulkUsersFromTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkUsersActionResponse>> BulkApplyTemplateToUsersAsync(BulkUsersApplyTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserWithTemplateAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserWithTemplateByUsernameAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<UserResponse>> ModifyUserWithTemplateByIdAsync(long userId, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> BulkModifyUsersExpireAsync(BulkUser request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> BulkModifyUsersDatalimitAsync(BulkUser request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> BulkModifyUsersProxySettingsAsync(BulkUsersProxy request, CancellationToken cancellationToken = default);

    Task<ApiResult<WireGuardPeerIPsReallocateResponse>> BulkReallocateWireguardPeerIpsAsync(BulkWireGuardPeerIPs request, CancellationToken cancellationToken = default);
}
