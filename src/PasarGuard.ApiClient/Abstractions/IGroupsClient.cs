using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IGroupsClient
{
    Task<ApiResult<GroupResponse>> CreateGroupAsync(GroupCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<GroupsResponse>> GetAllGroupsAsync(long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    Task<ApiResult<GroupsSimpleResponse>> GetGroupsSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<GroupResponse>> GetGroupAsync(long groupId, CancellationToken cancellationToken = default);

    Task<ApiResult<GroupResponse>> ModifyGroupAsync(long groupId, GroupModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveGroupAsync(long groupId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> BulkAddGroupsToUsersAsync(BulkGroup request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> BulkRemoveUsersFromGroupsAsync(BulkGroup request, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveGroupsResponse>> BulkDeleteGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkGroupsActionResponse>> BulkDisableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkGroupsActionResponse>> BulkEnableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);
}
