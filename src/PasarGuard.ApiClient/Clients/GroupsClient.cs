using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class GroupsClient : ApiClientBase, IGroupsClient
{
    public GroupsClient(HttpClient httpClient, ILogger<GroupsClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/group", "create_group")]
    public Task<ApiResult<GroupResponse>> CreateGroupAsync(GroupCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/group";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/group/{group_id}", "remove_group")]
    public Task<ApiResult> RemoveGroupAsync(long groupId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/group/{group_id}", "get_group")]
    public Task<ApiResult<GroupResponse>> GetGroupAsync(long groupId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/group/{group_id}", "modify_group")]
    public Task<ApiResult<GroupResponse>> ModifyGroupAsync(long groupId, GroupModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/groups", "get_all_groups")]
    public Task<ApiResult<GroupsResponse>> GetAllGroupsAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit);
        var url = query.Build(path);
        return SendAsync<GroupsResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/groups/bulk/add", "bulk_add_groups_to_users")]
    public Task<ApiResult<JsonElement>> BulkAddGroupsToUsersAsync(BulkGroup request, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/bulk/add";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/groups/bulk/delete", "bulk_delete_groups")]
    public Task<ApiResult<RemoveGroupsResponse>> BulkDeleteGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/bulk/delete";
        var url = path;
        return SendAsync<RemoveGroupsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/groups/bulk/disable", "bulk_disable_groups")]
    public Task<ApiResult<BulkGroupsActionResponse>> BulkDisableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/bulk/disable";
        var url = path;
        return SendAsync<BulkGroupsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/groups/bulk/enable", "bulk_enable_groups")]
    public Task<ApiResult<BulkGroupsActionResponse>> BulkEnableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/bulk/enable";
        var url = path;
        return SendAsync<BulkGroupsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/groups/bulk/remove", "bulk_remove_users_from_groups")]
    public Task<ApiResult<JsonElement>> BulkRemoveUsersFromGroupsAsync(BulkGroup request, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/bulk/remove";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/groups/simple", "get_groups_simple")]
    public Task<ApiResult<GroupsSimpleResponse>> GetGroupsSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/groups/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<GroupsSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
