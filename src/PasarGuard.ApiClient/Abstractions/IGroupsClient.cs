using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface IGroupsClient
{
    [ApiEndpoint("POST", "/api/group", "create_group")]
    Task<ApiResult<GroupResponse>> CreateGroupAsync(GroupCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/group/{group_id}", "remove_group")]
    Task<ApiResult> RemoveGroupAsync(long groupId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/group/{group_id}", "get_group")]
    Task<ApiResult<GroupResponse>> GetGroupAsync(long groupId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/group/{group_id}", "modify_group")]
    Task<ApiResult<GroupResponse>> ModifyGroupAsync(long groupId, GroupModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/groups", "get_all_groups")]
    Task<ApiResult<GroupsResponse>> GetAllGroupsAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/groups/bulk/add", "bulk_add_groups_to_users")]
    Task<ApiResult<JsonElement>> BulkAddGroupsToUsersAsync(BulkGroup request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/groups/bulk/delete", "bulk_delete_groups")]
    Task<ApiResult<RemoveGroupsResponse>> BulkDeleteGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/groups/bulk/disable", "bulk_disable_groups")]
    Task<ApiResult<BulkGroupsActionResponse>> BulkDisableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/groups/bulk/enable", "bulk_enable_groups")]
    Task<ApiResult<BulkGroupsActionResponse>> BulkEnableGroupsAsync(BulkGroupSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/groups/bulk/remove", "bulk_remove_users_from_groups")]
    Task<ApiResult<JsonElement>> BulkRemoveUsersFromGroupsAsync(BulkGroup request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/groups/simple", "get_groups_simple")]
    Task<ApiResult<GroupsSimpleResponse>> GetGroupsSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
