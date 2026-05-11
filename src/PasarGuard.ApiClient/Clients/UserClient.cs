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

public sealed class UserClient : ApiClientBase, IUserClient
{
    public UserClient(HttpClient httpClient, ILogger<UserClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<UserResponse>> CreateUserAsync(UserCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserAsync(string username, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveUserAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> GetUserAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserByUsernameAsync(string username, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserByIdAsync(long userId, UserModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveUserByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> GetUserByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ResetUserDataUsageAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ResetUserDataUsageByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ResetUserDataUsageByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/reset";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> RevokeUserSubscriptionByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/revoke_sub";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ResetUsersDataUsageAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/reset";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserSubscriptionUpdateChart>> GetUsersSubUpdateChartAsync(long? userId = null, string? username = null, long? adminId = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/sub_update/chart";
        var query = new QueryStringBuilder()
            .Add(@"user_id", userId)
            .Add(@"username", username)
            .Add(@"admin_id", adminId);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateChart>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> SetOwnerAsync(string username, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/set_owner";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> SetOwnerByUsernameAsync(string username, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/set_owner";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> SetOwnerByIdAsync(long userId, string adminUsername, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/set_owner";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername);
        var url = query.Build(path);
        return SendAsync<UserResponse>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ActiveNextPlanAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ActiveNextPlanByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ActiveNextPlanByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/active_next";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> GetUserSubscriptionByIdAsync(long userId, ConfigFormat clientType, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(userId)}/subscription/{UrlEncoding.EncodePathSegment(clientType)}";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListAsync(string username, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/sub_update";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByUsernameAsync(string username, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/sub_update";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserSubscriptionUpdateList>> GetUserSubUpdateListByIdAsync(long userId, long? offset = 0L, long? limit = 10L, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/sub_update";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<UserSubscriptionUpdateList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UsersResponse>> GetUsersAsync(long? offset = null, long? limit = null, IEnumerable<string>? username = null, IEnumerable<string>? admin = null, IEnumerable<long>? group = null, string? search = null, UserStatus? status = null, string? sort = null, string? proxyId = null, bool? loadSub = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"username", username)
            .Add(@"admin", admin)
            .Add(@"group", group)
            .Add(@"search", search)
            .Add(@"status", status)
            .Add(@"sort", sort)
            .Add(@"proxy_id", proxyId)
            .Add(@"load_sub", loadSub);
        var url = query.Build(path);
        return SendAsync<UsersResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UsersSimpleResponse>> GetUsersSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/simple";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"search", search)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<UsersSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetUserUsageAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetUserUsageByUsernameAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-username/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetUserUsageByIdAsync(long userId, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/by-id/{UrlEncoding.EncodePathSegment(userId)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetUsersUsageAsync(Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, IEnumerable<string>? admin = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end)
            .Add(@"admin", admin);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<List<string>>> GetExpiredUsersAsync(string? adminUsername = null, string? target = @"expired", DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/expired";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername)
            .Add(@"target", target)
            .Add(@"expired_after", expiredAfter)
            .Add(@"expired_before", expiredBefore);
        var url = query.Build(path);
        return SendAsync<List<string>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveUsersResponse>> DeleteExpiredUsersAsync(string? adminUsername = null, string? target = @"expired", DateTimeOffset? expiredAfter = null, DateTimeOffset? expiredBefore = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/expired";
        var query = new QueryStringBuilder()
            .Add(@"admin_username", adminUsername)
            .Add(@"target", target)
            .Add(@"expired_after", expiredAfter)
            .Add(@"expired_before", expiredBefore);
        var url = query.Build(path);
        return SendAsync<RemoveUsersResponse>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveUsersResponse>> BulkDeleteUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/delete";
        var url = path;
        return SendAsync<RemoveUsersResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkResetUsersDataUsageAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/reset";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkDisableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/disable";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkEnableUsersAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/enable";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkRevokeUsersSubscriptionAsync(BulkUsersSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/revoke_sub";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkSetOwnerAsync(BulkUsersSetOwner request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/set_owner";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> CreateUserFromTemplateAsync(CreateUserFromTemplate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/user/from_template";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersCreateResponse>> BulkCreateUsersFromTemplateAsync(BulkUsersFromTemplate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/from_template";
        var url = path;
        return SendAsync<BulkUsersCreateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkUsersActionResponse>> BulkApplyTemplateToUsersAsync(BulkUsersApplyTemplate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/apply_template";
        var url = path;
        return SendAsync<BulkUsersActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/from_template/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateByUsernameAsync(string username, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/from_template/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<UserResponse>> ModifyUserWithTemplateByIdAsync(long userId, ModifyUserByTemplate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/user/from_template/by-id/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<UserResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> BulkModifyUsersExpireAsync(BulkUser request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/expire";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> BulkModifyUsersDatalimitAsync(BulkUser request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/data_limit";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> BulkModifyUsersProxySettingsAsync(BulkUsersProxy request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/proxy_settings";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<WireGuardPeerIPsReallocateResponse>> BulkReallocateWireguardPeerIpsAsync(BulkWireGuardPeerIPs request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/users/bulk/wireguard/reallocate-peer-ips";
        var url = path;
        return SendAsync<WireGuardPeerIPsReallocateResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
