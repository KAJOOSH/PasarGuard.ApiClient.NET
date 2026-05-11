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

public sealed class AdminClient : ApiClientBase, IAdminClient
{
    public AdminClient(HttpClient httpClient, ILogger<AdminClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<Token>> AdminTokenAsync(BodyAdminTokenApiAdminTokenPost request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admin/token";
        var url = path;
        return SendAsync<Token>(HttpMethod.Post, url, request, RequestBodyKind.FormUrlEncoded, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> AdminMiniAppTokenAsync(string xTelegramAuthorization, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admin/miniapp/token";
        var url = path;
        var headers = new Dictionary<string, string?>
        {
            [@"x-telegram-authorization"] = ValueFormatter.FormatNullable(xTelegramAuthorization)
        };
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, headers, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> GetCurrentAdminAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/admin";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> CreateAdminAsync(AdminCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admin";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ModifyAdminAsync(string username, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveAdminAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ModifyAdminByUsernameAsync(string username, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveAdminByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ModifyAdminByIdAsync(long adminId, AdminModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveAdminByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminsResponse>> GetAdminsAsync(string? username = null, long? offset = null, long? limit = null, string? sort = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins";
        var query = new QueryStringBuilder()
            .Add(@"username", username)
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"sort", sort);
        var url = query.Build(path);
        return SendAsync<AdminsResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminsSimpleResponse>> GetAdminsSimpleAsync(string? search = null, long? offset = null, long? limit = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/simple";
        var query = new QueryStringBuilder()
            .Add(@"search", search)
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<AdminsSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageByUsernameAsync(string username, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserUsageStatsList>> GetAdminUsageByIdAsync(long adminId, Period period, long? nodeId = null, bool? groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/usage";
        var query = new QueryStringBuilder()
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode)
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<UserUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> DisableAllActiveUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> DisableAllActiveUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> DisableAllActiveUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users/disable";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ActivateAllDisabledUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users/activate";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> RemoveAllUsersAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> RemoveAllUsersByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> RemoveAllUsersByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/users";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ResetAdminUsageAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ResetAdminUsageByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-username/{UrlEncoding.EncodePathSegment(username)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<AdminDetails>> ResetAdminUsageByIdAsync(long adminId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/admin/by-id/{UrlEncoding.EncodePathSegment(adminId)}/reset";
        var url = path;
        return SendAsync<AdminDetails>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveAdminsResponse>> BulkDeleteAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/delete";
        var url = path;
        return SendAsync<RemoveAdminsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkResetAdminsUsageAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/reset";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/disable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkEnableAdminsAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/enable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkDisableAllActiveUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/users/disable";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkActivateAllDisabledUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/users/activate";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkAdminsActionResponse>> BulkRemoveAllUsersAsync(BulkAdminSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/admins/bulk/users";
        var url = path;
        return SendAsync<BulkAdminsActionResponse>(HttpMethod.Delete, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
