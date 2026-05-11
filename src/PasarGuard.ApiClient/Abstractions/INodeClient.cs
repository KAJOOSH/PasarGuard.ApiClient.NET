using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface INodeClient
{
    Task<ApiResult<NodeSettings>> GetNodeSettingsAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<NodeUsageStatsList>> GetUsageAsync(DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, long? nodeId = null, bool? groupByNode = false, CancellationToken cancellationToken = default);

    Task<ApiResult<NodesResponse>> GetNodesAsync(long? coreId = null, long? offset = null, long? limit = null, IEnumerable<NodeStatus>? status = null, bool? enabled = false, IEnumerable<long>? ids = null, string? search = null, CancellationToken cancellationToken = default);

    Task<ApiResult<NodesSimpleResponse>> GetNodesSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ReconnectAllNodeAsync(long? coreId = null, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeResponse>> CreateNodeAsync(NodeCreate request, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeResponse>> GetNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeResponse>> ModifyNodeAsync(long nodeId, NodeModify request, CancellationToken cancellationToken = default);

    Task<ApiResult> RemoveNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> UpdateNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> UpdateCoreAsync(long nodeId, NodeCoreUpdate request, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> UpdateGeofilesAsync(long nodeId, NodeGeoFilesUpdate request, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeResponse>> ResetNodeUsageAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ReconnectNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> SyncNodeAsync(long nodeId, bool? flushUsers = false, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> NodeLogsAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeStatsList>> GetNodeStatsPeriodicAsync(long nodeId, DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, CancellationToken cancellationToken = default);

    Task<ApiResult<NodeRealtimeStats>> RealtimeNodeStatsAsync(long nodeId, CancellationToken cancellationToken = default);

    Task<ApiResult<Dictionary<string, NodeRealtimeStats?>>> RealtimeNodesStatsAsync(CancellationToken cancellationToken = default);

    Task<ApiResult<UserIPListAll>> UserOnlineIpListAllNodesAsync(string username, CancellationToken cancellationToken = default);

    Task<ApiResult<Dictionary<string, long>>> UserOnlineStatsAsync(long nodeId, string username, CancellationToken cancellationToken = default);

    Task<ApiResult<UserIPList>> UserOnlineIpListAsync(long nodeId, string username, CancellationToken cancellationToken = default);

    Task<ApiResult<JsonElement>> ClearUsageDataAsync(UsageTable table, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    Task<ApiResult<RemoveNodesResponse>> BulkDeleteNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkNodesActionResponse>> BulkDisableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkNodesActionResponse>> BulkEnableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkNodesActionResponse>> BulkResetNodesUsageAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkNodesActionResponse>> BulkReconnectNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    Task<ApiResult<BulkNodesActionResponse>> BulkUpdateNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);
}
