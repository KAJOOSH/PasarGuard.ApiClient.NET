using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class AdminClient : ApiClientBase, IAdminClient
{
    public AdminClient(HttpClient httpClient, ILogger<AdminClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("GET", "/api/admin", "get_current_admin")]
    public Task<ApiResult<AdminDetails>> GetCurrentAdminAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/admin";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin", "create_admin")]
    public Task<ApiResult<AdminDetails>> CreateAdminAsync(AdminCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admin";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/by-id/{admin_id}", "remove_admin_by_id")]
    public Task<ApiResult> RemoveAdminByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/admin/by-id/{admin_id}", "modify_admin_by_id")]
    public Task<ApiResult<AdminDetails>> ModifyAdminByIdAsync(long adminId, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/reset", "reset_admin_usage_by_id")]
    public Task<ApiResult<AdminDetails>> ResetAdminUsageByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin/by-id/{admin_id}/usage", "get_admin_usage_by_id")]
    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageByIdAsync(long adminId, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/by-id/{admin_id}/users", "remove_all_users_by_id")]
    public Task<ApiResult<JsonElement>> RemoveAllUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/users/activate", "activate_all_disabled_users_by_id")]
    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-id/{admin_id}/users/disable", "disable_all_active_users_by_id")]
    public Task<ApiResult<JsonElement>> DisableAllActiveUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/by-username/{username}", "remove_admin_by_username")]
    public Task<ApiResult> RemoveAdminByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/admin/by-username/{username}", "modify_admin_by_username")]
    public Task<ApiResult<AdminDetails>> ModifyAdminByUsernameAsync(string username, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/reset", "reset_admin_usage_by_username")]
    public Task<ApiResult<AdminDetails>> ResetAdminUsageByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin/by-username/{username}/usage", "get_admin_usage_by_username")]
    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageByUsernameAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/by-username/{username}/users", "remove_all_users_by_username")]
    public Task<ApiResult<JsonElement>> RemoveAllUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/users/activate", "activate_all_disabled_users_by_username")]
    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/by-username/{username}/users/disable", "disable_all_active_users_by_username")]
    public Task<ApiResult<JsonElement>> DisableAllActiveUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/miniapp/token", "admin_mini_app_token")]
    public Task<ApiResult<JsonElement>> AdminMiniAppTokenAsync(string xTelegramAuthorization, CancellationToken cancellationToken = default)
    {
        var path = "/api/admin/miniapp/token";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            ["x-telegram-authorization"] = ValueFormatter.FormatNullable(xTelegramAuthorization)
        };
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, headers, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/token", "admin_token")]
    public Task<ApiResult<Token>> AdminTokenAsync(BodyAdminToken request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admin/token";
        var url = path;
        return SendAsync<Token>(HttpMethod.Post, url, request, RequestBodyKind.FormUrlEncoded, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/{username}", "remove_admin")]
    public Task<ApiResult> RemoveAdminAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/admin/{username}", "modify_admin")]
    public Task<ApiResult<AdminDetails>> ModifyAdminAsync(string username, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/{username}/reset", "reset_admin_usage")]
    public Task<ApiResult<AdminDetails>> ResetAdminUsageAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admin/{username}/usage", "get_admin_usage")]
    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageAsync(string username, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admin/{username}/users", "remove_all_users")]
    public Task<ApiResult<JsonElement>> RemoveAllUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/{username}/users/activate", "activate_all_disabled_users")]
    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admin/{username}/users/disable", "disable_all_active_users")]
    public Task<ApiResult<JsonElement>> DisableAllActiveUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admins", "get_admins")]
    public Task<ApiResult<AdminsResponse>> GetAdminsAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, string? username = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("usernames", usernames)
            .Add("username", username)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("sort", sort);
        var url = query.Build(path);
        return SendAsync<AdminsResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/delete", "bulk_delete_admins")]
    public Task<ApiResult<RemoveAdminsResponse>> BulkDeleteAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/delete";
        var url = path;
        return SendAsync<RemoveAdminsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/disable", "bulk_disable_admins")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/disable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/enable", "bulk_enable_admins")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkEnableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/enable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/reset", "bulk_reset_admins_usage")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkResetAdminsUsageAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/reset";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/admins/bulk/users", "bulk_remove_all_users")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkRemoveAllUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/users";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Delete, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/users/activate", "bulk_activate_all_disabled_users")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkActivateAllDisabledUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/users/activate";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/admins/bulk/users/disable", "bulk_disable_all_active_users")]
    public Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAllActiveUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/bulk/users/disable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/admins/simple", "get_admins_simple")]
    public Task<ApiResult<AdminsSimpleResponse>> GetAdminsSimpleAsync(IReadOnlyList<long>? ids = null, IReadOnlyList<string>? usernames = null, string? search = null, long? offset = null, long? limit = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/admins/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("usernames", usernames)
            .Add("search", search)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<AdminsSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
