using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IUserClient
{
    [ApiEndpoint("POST", "/api/user", "create_user")]
    Task<ApiResult<UserResponse>> CreateUserAsync(UserCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/user/by-id/{user_id}", "remove_user_by_id")]
    Task<ApiResult> RemoveUserByIdAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}", "get_user_by_id")]
    Task<ApiResult<UserResponse>> GetUserByIdAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}", "modify_user_by_id")]
    Task<ApiResult<UserResponse>> ModifyUserByIdAsync(long userId, UserModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/active_next", "active_next_plan_by_id")]
    Task<ApiResult<UserResponse>> ActiveNextPlanByIdAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}/disabled", "set_user_disabled_by_id")]
    Task<ApiResult<UserResponse>> SetUserDisabledByIdAsync(long userId, UserStatusToggle request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/reset", "reset_user_data_usage_by_id")]
    Task<ApiResult<UserResponse>> ResetUserDataUsageByIdAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/revoke_sub", "revoke_user_subscription_by_id")]
    Task<ApiResult<UserResponse>> RevokeUserSubscriptionByIdAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}/set_owner", "set_owner_by_id")]
    Task<ApiResult<UserResponse>> SetOwnerByIdAsync(long userId, string adminUsername, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}/sub_update", "get_user_sub_update_list_by_id")]
    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByIdAsync(long userId, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}/usage", "get_user_usage_by_id")]
    Task<ApiResult<UserUsageStatsList>> GetUserUsageByIdAsync(long userId, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/user/by-username/{username}", "remove_user_by_username")]
    Task<ApiResult> RemoveUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-username/{username}", "get_user_by_username")]
    Task<ApiResult<UserResponse>> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-username/{username}", "modify_user_by_username")]
    Task<ApiResult<UserResponse>> ModifyUserByUsernameAsync(string username, UserModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-username/{username}/active_next", "active_next_plan_by_username")]
    Task<ApiResult<UserResponse>> ActiveNextPlanByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-username/{username}/disabled", "set_user_disabled_by_username")]
    Task<ApiResult<UserResponse>> SetUserDisabledByUsernameAsync(string username, UserStatusToggle request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-username/{username}/reset", "reset_user_data_usage_by_username")]
    Task<ApiResult<UserResponse>> ResetUserDataUsageByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/by-username/{username}/revoke_sub", "revoke_user_subscription_by_username")]
    Task<ApiResult<UserResponse>> RevokeUserSubscriptionByUsernameAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/by-username/{username}/set_owner", "set_owner_by_username")]
    Task<ApiResult<UserResponse>> SetOwnerByUsernameAsync(string username, string adminUsername, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-username/{username}/sub_update", "get_user_sub_update_list_by_username")]
    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByUsernameAsync(string username, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/by-username/{username}/usage", "get_user_usage_by_username")]
    Task<ApiResult<UserUsageStatsList>> GetUserUsageByUsernameAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/from_template", "create_user_from_template")]
    Task<ApiResult<UserResponse>> CreateUserFromTemplateAsync(CreateUserFromTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/from_template/by-id/{user_id}", "modify_user_with_template_by_id")]
    Task<ApiResult<UserResponse>> ModifyUserWithTemplateByIdAsync(long userId, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/from_template/by-username/{username}", "modify_user_with_template_by_username")]
    Task<ApiResult<UserResponse>> ModifyUserWithTemplateByUsernameAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/from_template/{username}", "modify_user_with_template")]
    Task<ApiResult<UserResponse>> ModifyUserWithTemplateAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/{user_id}/subscription/{client_type}", "get_user_subscription_by_id")]
    Task<ApiResult<JsonElement>> GetUserSubscriptionByIdAsync(long userId, ConfigFormat clientType, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/user/{username}", "remove_user")]
    Task<ApiResult> RemoveUserAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/{username}", "get_user")]
    Task<ApiResult<UserResponse>> GetUserAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/{username}", "modify_user")]
    Task<ApiResult<UserResponse>> ModifyUserAsync(string username, UserModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/{username}/active_next", "active_next_plan")]
    Task<ApiResult<UserResponse>> ActiveNextPlanAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/{username}/disabled", "set_user_disabled")]
    Task<ApiResult<UserResponse>> SetUserDisabledAsync(string username, UserStatusToggle request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/{username}/reset", "reset_user_data_usage")]
    Task<ApiResult<UserResponse>> ResetUserDataUsageAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/user/{username}/revoke_sub", "revoke_user_subscription")]
    Task<ApiResult<UserResponse>> RevokeUserSubscriptionAsync(string username, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/user/{username}/set_owner", "set_owner")]
    Task<ApiResult<UserResponse>> SetOwnerAsync(string username, string adminUsername, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/{username}/sub_update", "get_user_sub_update_list")]
    Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListAsync(string username, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/user/{username}/usage", "get_user_usage")]
    Task<ApiResult<UserUsageStatsList>> GetUserUsageAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users", "get_users")]
    Task<ApiResult<UsersResponse>> GetUsersAsync(long? offset = null, long? limit = null, IReadOnlyList<long>? ids = null, IReadOnlyList<string>? username = null, IReadOnlyList<string>? usernames = null, IReadOnlyList<string>? admin = null, IReadOnlyList<long>? adminIds = null, IReadOnlyList<long>? group = null, bool noGroup = false, string? search = null, JsonElement? status = null, string? sort = null, string? proxyId = null, JsonElement? dataLimitResetStrategy = null, long? dataLimitMin = null, long? dataLimitMax = null, DateTimeOffset? expireAfter = null, DateTimeOffset? expireBefore = null, DateTimeOffset? onlineAfter = null, DateTimeOffset? onlineBefore = null, bool online = false, bool noDataLimit = false, bool noExpire = false, bool loadSub = false, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/apply_template", "bulk_apply_template_to_users")]
    Task<ApiResult<BulkUsersActionResponse>> BulkApplyTemplateToUsersAsync(BulkUsersApplyTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/data_limit", "bulk_modify_users_datalimit")]
    Task<ApiResult<JsonElement>> BulkModifyUsersDatalimitAsync(BulkUser request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/delete", "bulk_delete_users")]
    Task<ApiResult<RemoveUsersResponse>> BulkDeleteUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/disable", "bulk_disable_users")]
    Task<ApiResult<BulkUsersActionResponse>> BulkDisableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/enable", "bulk_enable_users")]
    Task<ApiResult<BulkUsersActionResponse>> BulkEnableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/expire", "bulk_modify_users_expire")]
    Task<ApiResult<JsonElement>> BulkModifyUsersExpireAsync(BulkUser request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/from_template", "bulk_create_users_from_template")]
    Task<ApiResult<BulkUsersCreateResponse>> BulkCreateUsersFromTemplateAsync(BulkUsersFromTemplate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/proxy_settings", "bulk_modify_users_proxy_settings")]
    Task<ApiResult<JsonElement>> BulkModifyUsersProxySettingsAsync(BulkUsersProxy request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/reset", "bulk_reset_users_data_usage")]
    Task<ApiResult<BulkUsersActionResponse>> BulkResetUsersDataUsageAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/bulk/revoke_sub", "bulk_revoke_users_subscription")]
    Task<ApiResult<BulkUsersActionResponse>> BulkRevokeUsersSubscriptionAsync(BulkUsersSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/users/bulk/set_owner", "bulk_set_owner")]
    Task<ApiResult<BulkUsersActionResponse>> BulkSetOwnerAsync(BulkUsersSetOwner request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users/counts/{metric}", "get_users_count_metric")]
    Task<ApiResult<UserCountMetricStatsList>> GetUsersCountMetricAsync(UserCountMetric metric, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IReadOnlyList<string>? admin = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/users/expired", "delete_expired_users")]
    Task<ApiResult<RemoveUsersResponse>> DeleteExpiredUsersAsync(string? adminUsername = null, UserStatus target = UserStatus.Expired, DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, bool dryRun = false, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users/expired", "get_expired_users")]
    Task<ApiResult<IReadOnlyList<string>>> GetExpiredUsersAsync(string? adminUsername = null, UserStatus target = UserStatus.Expired, DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, bool dryRun = false, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/users/reset", "reset_users_data_usage")]
    Task<ApiResult<JsonElement>> ResetUsersDataUsageAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users/simple", "get_users_simple")]
    Task<ApiResult<UsersSimpleResponse>> GetUsersSimpleAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users/sub_update/chart", "get_users_sub_update_chart")]
    Task<ApiResult<UserSubscriptionUpdateChart>> GetUsersSubUpdateChartAsync(long? userId = null, string? username = null, long? adminId = null, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/users/usage", "get_users_usage")]
    Task<ApiResult<UserUsageStatsList>> GetUsersUsageAsync(Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IReadOnlyList<string>? admin = null, CancellationToken cancellationToken = default);
}
