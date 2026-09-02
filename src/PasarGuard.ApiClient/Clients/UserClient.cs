using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class UserClient : ApiClientBase, IUserClient
{
    public UserClient(HttpClient httpClient, ILogger<UserClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/user", "create_user")]
    public Task<ApiResult<UserResponse>> CreateUserAsync(UserCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/user/by-id/{user_id}", "remove_user_by_id")]
    public Task<ApiResult> RemoveUserByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}", "get_user_by_id")]
    public Task<ApiResult<UserResponse>> GetUserByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}", "modify_user_by_id")]
    public Task<ApiResult<UserResponse>> ModifyUserByIdAsync(long userId, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/active_next", "active_next_plan_by_id")]
    public Task<ApiResult<UserResponse>> ActiveNextPlanByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}/disabled", "set_user_disabled_by_id")]
    public Task<ApiResult<UserResponse>> SetUserDisabledByIdAsync(long userId, UserStatusToggle request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/disabled";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/reset", "reset_user_data_usage_by_id")]
    public Task<ApiResult<UserResponse>> ResetUserDataUsageByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-id/{user_id}/revoke_sub", "revoke_user_subscription_by_id")]
    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-id/{user_id}/set_owner", "set_owner_by_id")]
    public Task<ApiResult<UserResponse>> SetOwnerByIdAsync(long userId, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/set_owner";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}/sub_update", "get_user_sub_update_list_by_id")]
    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByIdAsync(long userId, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/sub_update";
        var query = new QueryStringBuilder()
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-id/{user_id}/usage", "get_user_usage_by_id")]
    public Task<ApiResult<UserUsageStatsList>> GetUserUsageByIdAsync(long userId, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/user/by-username/{username}", "remove_user_by_username")]
    public Task<ApiResult> RemoveUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-username/{username}", "get_user_by_username")]
    public Task<ApiResult<UserResponse>> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-username/{username}", "modify_user_by_username")]
    public Task<ApiResult<UserResponse>> ModifyUserByUsernameAsync(string username, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-username/{username}/active_next", "active_next_plan_by_username")]
    public Task<ApiResult<UserResponse>> ActiveNextPlanByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-username/{username}/disabled", "set_user_disabled_by_username")]
    public Task<ApiResult<UserResponse>> SetUserDisabledByUsernameAsync(string username, UserStatusToggle request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/disabled";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-username/{username}/reset", "reset_user_data_usage_by_username")]
    public Task<ApiResult<UserResponse>> ResetUserDataUsageByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/by-username/{username}/revoke_sub", "revoke_user_subscription_by_username")]
    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/by-username/{username}/set_owner", "set_owner_by_username")]
    public Task<ApiResult<UserResponse>> SetOwnerByUsernameAsync(string username, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/set_owner";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-username/{username}/sub_update", "get_user_sub_update_list_by_username")]
    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByUsernameAsync(string username, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/sub_update";
        var query = new QueryStringBuilder()
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/by-username/{username}/usage", "get_user_usage_by_username")]
    public Task<ApiResult<UserUsageStatsList>> GetUserUsageByUsernameAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/from_template", "create_user_from_template")]
    public Task<ApiResult<UserResponse>> CreateUserFromTemplateAsync(CreateUserFromTemplate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/user/from_template";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/from_template/by-id/{user_id}", "modify_user_with_template_by_id")]
    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateByIdAsync(long userId, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/from_template/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/from_template/by-username/{username}", "modify_user_with_template_by_username")]
    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateByUsernameAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/from_template/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/from_template/{username}", "modify_user_with_template")]
    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/from_template/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/{user_id}/subscription/{client_type}", "get_user_subscription_by_id")]
    public Task<ApiResult<JsonElement>> GetUserSubscriptionByIdAsync(long userId, ConfigFormat clientType, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(userId)}/subscription/{UrlEncoding.EncodePathSegment(clientType)}";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/user/{username}", "remove_user")]
    public Task<ApiResult> RemoveUserAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/{username}", "get_user")]
    public Task<ApiResult<UserResponse>> GetUserAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/{username}", "modify_user")]
    public Task<ApiResult<UserResponse>> ModifyUserAsync(string username, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/{username}/active_next", "active_next_plan")]
    public Task<ApiResult<UserResponse>> ActiveNextPlanAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/{username}/disabled", "set_user_disabled")]
    public Task<ApiResult<UserResponse>> SetUserDisabledAsync(string username, UserStatusToggle request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/disabled";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/{username}/reset", "reset_user_data_usage")]
    public Task<ApiResult<UserResponse>> ResetUserDataUsageAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/user/{username}/revoke_sub", "revoke_user_subscription")]
    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/user/{username}/set_owner", "set_owner")]
    public Task<ApiResult<UserResponse>> SetOwnerAsync(string username, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/set_owner";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/{username}/sub_update", "get_user_sub_update_list")]
    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListAsync(string username, long offset = 0L, long limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/sub_update";
        var query = new QueryStringBuilder()
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/user/{username}/usage", "get_user_usage")]
    public Task<ApiResult<UserUsageStatsList>> GetUserUsageAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/user/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users", "get_users")]
    public Task<ApiResult<UsersResponse>> GetUsersAsync(long? offset = null, long? limit = null, IReadOnlyList<long>? ids = null, IReadOnlyList<string>? username = null, IReadOnlyList<string>? usernames = null, IReadOnlyList<string>? admin = null, IReadOnlyList<long>? adminIds = null, IReadOnlyList<long>? group = null, bool noGroup = false, string? search = null, JsonElement? status = null, string? sort = null, string? proxyId = null, JsonElement? dataLimitResetStrategy = null, long? dataLimitMin = null, long? dataLimitMax = null, DateTimeOffset? expireAfter = null, DateTimeOffset? expireBefore = null, DateTimeOffset? onlineAfter = null, DateTimeOffset? onlineBefore = null, bool online = false, bool noDataLimit = false, bool noExpire = false, bool loadSub = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/users";
        var query = new QueryStringBuilder()
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("ids", ids)
            .Add("username", username)
            .Add("usernames", usernames)
            .Add("admin", admin)
            .Add("admin_ids", adminIds)
            .Add("group", group)
            .Add("no_group", noGroup)
            .Add("search", search)
            .Add("status", status)
            .Add("sort", sort)
            .Add("proxy_id", proxyId)
            .Add("data_limit_reset_strategy", dataLimitResetStrategy)
            .Add("data_limit_min", dataLimitMin)
            .Add("data_limit_max", dataLimitMax)
            .Add("expire_after", expireAfter)
            .Add("expire_before", expireBefore)
            .Add("online_after", onlineAfter)
            .Add("online_before", onlineBefore)
            .Add("online", online)
            .Add("no_data_limit", noDataLimit)
            .Add("no_expire", noExpire)
            .Add("load_sub", loadSub);
        var url = query.Build(path);
        return SendAsync<UsersResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/apply_template", "bulk_apply_template_to_users")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkApplyTemplateToUsersAsync(BulkUsersApplyTemplate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/apply_template";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/data_limit", "bulk_modify_users_datalimit")]
    public Task<ApiResult<JsonElement>> BulkModifyUsersDatalimitAsync(BulkUser request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/data_limit";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/delete", "bulk_delete_users")]
    public Task<ApiResult<RemoveUsersResponse>> BulkDeleteUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/delete";
        var url = path;
        return SendAsync<RemoveUsersResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/disable", "bulk_disable_users")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkDisableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/disable";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/enable", "bulk_enable_users")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkEnableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/enable";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/expire", "bulk_modify_users_expire")]
    public Task<ApiResult<JsonElement>> BulkModifyUsersExpireAsync(BulkUser request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/expire";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/from_template", "bulk_create_users_from_template")]
    public Task<ApiResult<BulkUsersCreateResponse>> BulkCreateUsersFromTemplateAsync(BulkUsersFromTemplate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/from_template";
        var url = path;
        return SendAsync<BulkUsersCreateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/proxy_settings", "bulk_modify_users_proxy_settings")]
    public Task<ApiResult<JsonElement>> BulkModifyUsersProxySettingsAsync(BulkUsersProxy request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/proxy_settings";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/reset", "bulk_reset_users_data_usage")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkResetUsersDataUsageAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/reset";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/bulk/revoke_sub", "bulk_revoke_users_subscription")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkRevokeUsersSubscriptionAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/revoke_sub";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/users/bulk/set_owner", "bulk_set_owner")]
    public Task<ApiResult<BulkUsersActionResponse>> BulkSetOwnerAsync(BulkUsersSetOwner request, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/bulk/set_owner";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users/counts/{metric}", "get_users_count_metric")]
    public Task<ApiResult<UserCountMetricStatsList>> GetUsersCountMetricAsync(UserCountMetric metric, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IReadOnlyList<string>? admin = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/users/counts/{UrlEncoding.EncodePathSegment(metric)}";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end)
            .Add("admin", admin);
        var url = query.Build(path);
        return SendAsync<UserCountMetricStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/users/expired", "delete_expired_users")]
    public Task<ApiResult<RemoveUsersResponse>> DeleteExpiredUsersAsync(string? adminUsername = null, UserStatus target = UserStatus.Expired, DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, bool dryRun = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/expired";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername)
            .Add("target", target)
            .Add("expired_after", expiredAfter)
            .Add("expired_before", expiredBefore)
            .Add("dry_run", dryRun);
        var url = query.Build(path);
        return SendAsync<RemoveUsersResponse>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users/expired", "get_expired_users")]
    public Task<ApiResult<IReadOnlyList<string>>> GetExpiredUsersAsync(string? adminUsername = null, UserStatus target = UserStatus.Expired, DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, bool dryRun = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/expired";
        var query = new QueryStringBuilder()
            .Add("admin_username", adminUsername)
            .Add("target", target)
            .Add("expired_after", expiredAfter)
            .Add("expired_before", expiredBefore)
            .Add("dry_run", dryRun);
        var url = query.Build(path);
        return SendAsync<IReadOnlyList<string>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/users/reset", "reset_users_data_usage")]
    public Task<ApiResult<JsonElement>> ResetUsersDataUsageAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/users/reset";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users/simple", "get_users_simple")]
    public Task<ApiResult<UsersSimpleResponse>> GetUsersSimpleAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("usernames", usernames)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<UsersSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users/sub_update/chart", "get_users_sub_update_chart")]
    public Task<ApiResult<UserSubscriptionUpdateChart>> GetUsersSubUpdateChartAsync(long? userId = null, string? username = null, long? adminId = null, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/sub_update/chart";
        var query = new QueryStringBuilder()
            .Add("user_id", userId)
            .Add("username", username)
            .Add("admin_id", adminId)
            .Add("period", period)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateChart>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/users/usage", "get_users_usage")]
    public Task<ApiResult<UserUsageStatsList>> GetUsersUsageAsync(Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IReadOnlyList<string>? admin = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/users/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end)
            .Add("admin", admin);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
