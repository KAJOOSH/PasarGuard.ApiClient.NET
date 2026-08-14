using System.Text.Json;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Abstractions;

public interface INodeClient
{
    [ApiEndpoint("POST", "/api/node", "create_node")]
    Task<ApiResult<NodeResponse>> CreateNodeAsync(NodeCreate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/online_stats/{user_id}/ip", "user_online_ip_list_all_nodes")]
    Task<ApiResult<UserIPListAll>> UserOnlineIpListAllNodesAsync(long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/settings", "get_node_settings")]
    Task<ApiResult<NodeSettings>> GetNodeSettingsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/usage", "get_usage")]
    Task<ApiResult<NodeUsageStatsList>> GetUsageAsync(Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/user_counts/{metric}", "get_user_count_metric")]
    Task<ApiResult<UserCountMetricStatsList>> GetUserCountMetricAsync(UserCountMetric metric, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/node/{node_id}", "remove_node")]
    Task<ApiResult> RemoveNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}", "get_node")]
    Task<ApiResult<NodeResponse>> GetNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/node/{node_id}", "modify_node")]
    Task<ApiResult<NodeResponse>> ModifyNodeAsync(long nodeId, NodeModify request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/node/{node_id}/core_update", "update_core")]
    Task<ApiResult<JsonElement>> UpdateCoreAsync(long nodeId, NodeCoreUpdate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/node/{node_id}/geofiles", "update_geofiles")]
    Task<ApiResult<JsonElement>> UpdateGeofilesAsync(long nodeId, NodeGeoFilesUpdate request, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/logs", "node_logs")]
    Task<ApiResult<JsonElement>> NodeLogsAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/online_stats/{user_id}", "user_online_stats")]
    Task<ApiResult<IReadOnlyDictionary<string, long>>> UserOnlineStatsAsync(long nodeId, long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/online_stats/{user_id}/ip", "user_online_ip_list")]
    Task<ApiResult<UserIPList>> UserOnlineIpListAsync(long nodeId, long userId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/outbounds_latency", "node_outbounds_latency")]
    Task<ApiResult<NodeOutboundsLatencyResponse>> NodeOutboundsLatencyAsync(long nodeId, string name = "", long? timeout = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/realtime_stats", "realtime_node_stats")]
    Task<ApiResult<NodeRealtimeStats>> RealtimeNodeStatsAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/node/{node_id}/reconnect", "reconnect_node")]
    Task<ApiResult<JsonElement>> ReconnectNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/node/{node_id}/reset", "reset_node_usage")]
    Task<ApiResult<NodeResponse>> ResetNodeUsageAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/node/{node_id}/stats", "get_node_stats_periodic")]
    Task<ApiResult<NodeStatsList>> GetNodeStatsPeriodicAsync(long nodeId, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("PUT", "/api/node/{node_id}/sync", "sync_node")]
    Task<ApiResult<JsonElement>> SyncNodeAsync(long nodeId, bool flushUsers = true, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/node/{node_id}/update", "update_node")]
    Task<ApiResult<JsonElement>> UpdateNodeAsync(long nodeId, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/nodes", "get_nodes")]
    Task<ApiResult<NodesResponse>> GetNodesAsync(long? coreId = null, long? offset = null, long? limit = null, IReadOnlyList<long>? ids = null, JsonElement? status = null, bool enabled = false, string? search = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/delete", "bulk_delete_nodes")]
    Task<ApiResult<RemoveNodesResponse>> BulkDeleteNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/disable", "bulk_disable_nodes")]
    Task<ApiResult<BulkNodesActionResponse>> BulkDisableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/enable", "bulk_enable_nodes")]
    Task<ApiResult<BulkNodesActionResponse>> BulkEnableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/reconnect", "bulk_reconnect_nodes")]
    Task<ApiResult<BulkNodesActionResponse>> BulkReconnectNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/reset", "bulk_reset_nodes_usage")]
    Task<ApiResult<BulkNodesActionResponse>> BulkResetNodesUsageAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/bulk/update", "bulk_update_nodes")]
    Task<ApiResult<BulkNodesActionResponse>> BulkUpdateNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default);

    [ApiEndpoint("DELETE", "/api/nodes/clear_usage_data/{table}", "clear_usage_data")]
    Task<ApiResult<JsonElement>> ClearUsageDataAsync(UsageTable table, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/nodes/realtime_stats", "realtime_nodes_stats")]
    Task<ApiResult<IReadOnlyDictionary<string, NodeRealtimeStats>>> RealtimeNodesStatsAsync(CancellationToken cancellationToken = default);

    [ApiEndpoint("POST", "/api/nodes/reconnect", "reconnect_all_node")]
    Task<ApiResult<JsonElement>> ReconnectAllNodeAsync(long? coreId = null, CancellationToken cancellationToken = default);

    [ApiEndpoint("GET", "/api/nodes/simple", "get_nodes_simple")]
    Task<ApiResult<NodesSimpleResponse>> GetNodesSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default);
}
