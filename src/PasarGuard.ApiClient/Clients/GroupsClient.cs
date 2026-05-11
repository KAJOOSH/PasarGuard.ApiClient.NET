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

public sealed class GroupsClient : ApiClientBase, IGroupsClient
{
    public GroupsClient(HttpClient httpClient, ILogger<GroupsClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<GroupResponse>> CreateGroupAsync(GroupCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/group";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<GroupsResponse>> GetAllGroupsAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit);
        var url = query.Build(path);
        return SendAsync<GroupsResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<GroupsSimpleResponse>> GetGroupsSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/simple";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"search", search)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<GroupsSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<GroupResponse>> GetGroupAsync(long groupId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<GroupResponse>> ModifyGroupAsync(long groupId, GroupModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync<GroupResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveGroupAsync(long groupId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/group/{UrlEncoding.EncodePathSegment(groupId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> BulkAddGroupsToUsersAsync(BulkGroup request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/bulk/add";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> BulkRemoveUsersFromGroupsAsync(BulkGroup request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/bulk/remove";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<RemoveGroupsResponse>> BulkDeleteGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/bulk/delete";
        var url = path;
        return SendAsync<RemoveGroupsResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkGroupsActionResponse>> BulkDisableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/bulk/disable";
        var url = path;
        return SendAsync<BulkGroupsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkGroupsActionResponse>> BulkEnableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/groups/bulk/enable";
        var url = path;
        return SendAsync<BulkGroupsActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
