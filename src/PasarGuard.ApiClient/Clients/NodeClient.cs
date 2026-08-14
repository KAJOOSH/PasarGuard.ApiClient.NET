using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Clients;

public sealed class NodeClient : ApiClientBase, INodeClient
{
    public NodeClient(HttpClient httpClient, ILogger<NodeClient> logger) : base(httpClient, logger)
    {
    }

    [ApiEndpoint("POST", "/api/node", "create_node")]
    public Task<ApiResult<NodeResponse>> CreateNodeAsync(NodeCreate request, CancellationToken cancellationToken = default)
    {
        var path = "/api/node";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/online_stats/{user_id}/ip", "user_online_ip_list_all_nodes")]
    public Task<ApiResult<UserIPListAll>> UserOnlineIpListAllNodesAsync(long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/online_stats/{UrlEncoding.EncodePathSegment(userId)}/ip";
        var url = path;
        return SendAsync<UserIPListAll>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/settings", "get_node_settings")]
    public Task<ApiResult<NodeSettings>> GetNodeSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/node/settings";
        var url = path;
        return SendAsync<NodeSettings>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/usage", "get_usage")]
    public Task<ApiResult<NodeUsageStatsList>> GetUsageAsync(Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/node/usage";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<NodeUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/user_counts/{metric}", "get_user_count_metric")]
    public Task<ApiResult<UserCountMetricStatsList>> GetUserCountMetricAsync(UserCountMetric metric, Period period = Period.Hour, long? nodeId = null, bool groupByNode = false, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/user_counts/{UrlEncoding.EncodePathSegment(metric)}";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("node_id", nodeId)
            .Add("group_by_node", groupByNode)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<UserCountMetricStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/node/{node_id}", "remove_node")]
    public Task<ApiResult> RemoveNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}", "get_node")]
    public Task<ApiResult<NodeResponse>> GetNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/node/{node_id}", "modify_node")]
    public Task<ApiResult<NodeResponse>> ModifyNodeAsync(long nodeId, NodeModify request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/node/{node_id}/core_update", "update_core")]
    public Task<ApiResult<JsonElement>> UpdateCoreAsync(long nodeId, NodeCoreUpdate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/core_update";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/node/{node_id}/geofiles", "update_geofiles")]
    public Task<ApiResult<JsonElement>> UpdateGeofilesAsync(long nodeId, NodeGeoFilesUpdate request, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/geofiles";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/logs", "node_logs")]
    public Task<ApiResult<JsonElement>> NodeLogsAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/logs";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/online_stats/{user_id}", "user_online_stats")]
    public Task<ApiResult<IReadOnlyDictionary<string, long>>> UserOnlineStatsAsync(long nodeId, long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/online_stats/{UrlEncoding.EncodePathSegment(userId)}";
        var url = path;
        return SendAsync<IReadOnlyDictionary<string, long>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/online_stats/{user_id}/ip", "user_online_ip_list")]
    public Task<ApiResult<UserIPList>> UserOnlineIpListAsync(long nodeId, long userId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/online_stats/{UrlEncoding.EncodePathSegment(userId)}/ip";
        var url = path;
        return SendAsync<UserIPList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/outbounds_latency", "node_outbounds_latency")]
    public Task<ApiResult<NodeOutboundsLatencyResponse>> NodeOutboundsLatencyAsync(long nodeId, string name = "", long? timeout = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/outbounds_latency";
        var query = new QueryStringBuilder()
            .Add("name", name)
            .Add("timeout", timeout);
        var url = query.Build(path);
        return SendAsync<NodeOutboundsLatencyResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/realtime_stats", "realtime_node_stats")]
    public Task<ApiResult<NodeRealtimeStats>> RealtimeNodeStatsAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/realtime_stats";
        var url = path;
        return SendAsync<NodeRealtimeStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/node/{node_id}/reconnect", "reconnect_node")]
    public Task<ApiResult<JsonElement>> ReconnectNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/reconnect";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/node/{node_id}/reset", "reset_node_usage")]
    public Task<ApiResult<NodeResponse>> ResetNodeUsageAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/reset";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/node/{node_id}/stats", "get_node_stats_periodic")]
    public Task<ApiResult<NodeStatsList>> GetNodeStatsPeriodicAsync(long nodeId, Period period = Period.Hour, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/stats";
        var query = new QueryStringBuilder()
            .Add("period", period)
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<NodeStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("PUT", "/api/node/{node_id}/sync", "sync_node")]
    public Task<ApiResult<JsonElement>> SyncNodeAsync(long nodeId, bool flushUsers = true, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/sync";
        var query = new QueryStringBuilder()
            .Add("flush_users", flushUsers);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/node/{node_id}/update", "update_node")]
    public Task<ApiResult<JsonElement>> UpdateNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/update";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/nodes", "get_nodes")]
    public Task<ApiResult<NodesResponse>> GetNodesAsync(long? coreId = null, long? offset = null, long? limit = null, IReadOnlyList<long>? ids = null, JsonElement? status = null, bool enabled = false, string? search = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes";
        var query = new QueryStringBuilder()
            .Add("core_id", coreId)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("ids", ids)
            .Add("status", status)
            .Add("enabled", enabled)
            .Add("search", search);
        var url = query.Build(path);
        return SendAsync<NodesResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/delete", "bulk_delete_nodes")]
    public Task<ApiResult<RemoveNodesResponse>> BulkDeleteNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/delete";
        var url = path;
        return SendAsync<RemoveNodesResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/disable", "bulk_disable_nodes")]
    public Task<ApiResult<BulkNodesActionResponse>> BulkDisableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/disable";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/enable", "bulk_enable_nodes")]
    public Task<ApiResult<BulkNodesActionResponse>> BulkEnableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/enable";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/reconnect", "bulk_reconnect_nodes")]
    public Task<ApiResult<BulkNodesActionResponse>> BulkReconnectNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/reconnect";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/reset", "bulk_reset_nodes_usage")]
    public Task<ApiResult<BulkNodesActionResponse>> BulkResetNodesUsageAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/reset";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/bulk/update", "bulk_update_nodes")]
    public Task<ApiResult<BulkNodesActionResponse>> BulkUpdateNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/bulk/update";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    [ApiEndpoint("DELETE", "/api/nodes/clear_usage_data/{table}", "clear_usage_data")]
    public Task<ApiResult<JsonElement>> ClearUsageDataAsync(UsageTable table, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $"/api/nodes/clear_usage_data/{UrlEncoding.EncodePathSegment(table)}";
        var query = new QueryStringBuilder()
            .Add("start", start)
            .Add("end", end);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/nodes/realtime_stats", "realtime_nodes_stats")]
    public Task<ApiResult<IReadOnlyDictionary<string, NodeRealtimeStats>>> RealtimeNodesStatsAsync(CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/realtime_stats";
        var url = path;
        return SendAsync<IReadOnlyDictionary<string, NodeRealtimeStats>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("POST", "/api/nodes/reconnect", "reconnect_all_node")]
    public Task<ApiResult<JsonElement>> ReconnectAllNodeAsync(long? coreId = null, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/reconnect";
        var query = new QueryStringBuilder()
            .Add("core_id", coreId);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    [ApiEndpoint("GET", "/api/nodes/simple", "get_nodes_simple")]
    public Task<ApiResult<NodesSimpleResponse>> GetNodesSimpleAsync(IReadOnlyList<long>? ids = null, long? offset = null, long? limit = null, string? search = null, string? sort = null, bool all = false, CancellationToken cancellationToken = default)
    {
        var path = "/api/nodes/simple";
        var query = new QueryStringBuilder()
            .Add("ids", ids)
            .Add("offset", offset)
            .Add("limit", limit)
            .Add("search", search)
            .Add("sort", sort)
            .Add("all", all);
        var url = query.Build(path);
        return SendAsync<NodesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }
}
