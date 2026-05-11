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

public sealed class NodeClient : ApiClientBase, INodeClient
{
    public NodeClient(HttpClient httpClient, ILogger<NodeClient> logger) : base(httpClient, logger)
    {
    }

    public Task<ApiResult<NodeSettings>> GetNodeSettingsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/node/settings";
        var url = path;
        return SendAsync<NodeSettings>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodeUsageStatsList>> GetUsageAsync(DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, long? nodeId = null, bool? groupByNode = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/node/usage";
        var query = new QueryStringBuilder()
            .Add(@"start", start)
            .Add(@"end", end)
            .Add(@"period", period)
            .Add(@"node_id", nodeId)
            .Add(@"group_by_node", groupByNode);
        var url = query.Build(path);
        return SendAsync<NodeUsageStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodesResponse>> GetNodesAsync(long? coreId = null, long? offset = null, long? limit = null, IEnumerable<NodeStatus>? status = null, bool? enabled = false, IEnumerable<long>? ids = null, string? search = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes";
        var query = new QueryStringBuilder()
            .Add(@"core_id", coreId)
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"status", status)
            .Add(@"enabled", enabled)
            .Add(@"ids", ids)
            .Add(@"search", search);
        var url = query.Build(path);
        return SendAsync<NodesResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodesSimpleResponse>> GetNodesSimpleAsync(long? offset = null, long? limit = null, string? search = null, string? sort = null, bool? all = false, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/simple";
        var query = new QueryStringBuilder()
            .Add(@"offset", offset)
            .Add(@"limit", limit)
            .Add(@"search", search)
            .Add(@"sort", sort)
            .Add(@"all", all);
        var url = query.Build(path);
        return SendAsync<NodesSimpleResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ReconnectAllNodeAsync(long? coreId = null, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/reconnect";
        var query = new QueryStringBuilder()
            .Add(@"core_id", coreId);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodeResponse>> CreateNodeAsync(NodeCreate request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/node";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<NodeResponse>> GetNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodeResponse>> ModifyNodeAsync(long nodeId, NodeModify request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Put, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult> RemoveNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}";
        var url = path;
        return SendAsync(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> UpdateNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/update";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> UpdateCoreAsync(long nodeId, NodeCoreUpdate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/core_update";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> UpdateGeofilesAsync(long nodeId, NodeGeoFilesUpdate request, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/geofiles";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<NodeResponse>> ResetNodeUsageAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/reset";
        var url = path;
        return SendAsync<NodeResponse>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ReconnectNodeAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/reconnect";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Post, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> SyncNodeAsync(long nodeId, bool? flushUsers = false, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/sync";
        var query = new QueryStringBuilder()
            .Add(@"flush_users", flushUsers);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Put, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> NodeLogsAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/logs";
        var url = path;
        return SendAsync<JsonElement>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodeStatsList>> GetNodeStatsPeriodicAsync(long nodeId, DateTimeOffset? start = null, DateTimeOffset? end = null, Period? period = Period.Hour, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/stats";
        var query = new QueryStringBuilder()
            .Add(@"start", start)
            .Add(@"end", end)
            .Add(@"period", period);
        var url = query.Build(path);
        return SendAsync<NodeStatsList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<NodeRealtimeStats>> RealtimeNodeStatsAsync(long nodeId, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/realtime_stats";
        var url = path;
        return SendAsync<NodeRealtimeStats>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<Dictionary<string, NodeRealtimeStats?>>> RealtimeNodesStatsAsync(CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/realtime_stats";
        var url = path;
        return SendAsync<Dictionary<string, NodeRealtimeStats?>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserIPListAll>> UserOnlineIpListAllNodesAsync(string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/online_stats/{UrlEncoding.EncodePathSegment(username)}/ip";
        var url = path;
        return SendAsync<UserIPListAll>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<Dictionary<string, long>>> UserOnlineStatsAsync(long nodeId, string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/online_stats/{UrlEncoding.EncodePathSegment(username)}";
        var url = path;
        return SendAsync<Dictionary<string, long>>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<UserIPList>> UserOnlineIpListAsync(long nodeId, string username, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/node/{UrlEncoding.EncodePathSegment(nodeId)}/online_stats/{UrlEncoding.EncodePathSegment(username)}/ip";
        var url = path;
        return SendAsync<UserIPList>(HttpMethod.Get, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<JsonElement>> ClearUsageDataAsync(UsageTable table, DateTimeOffset? start = null, DateTimeOffset? end = null, CancellationToken cancellationToken = default)
    {
        var path = $@"/api/nodes/clear_usage_data/{UrlEncoding.EncodePathSegment(table)}";
        var query = new QueryStringBuilder()
            .Add(@"start", start)
            .Add(@"end", end);
        var url = query.Build(path);
        return SendAsync<JsonElement>(HttpMethod.Delete, url, null, RequestBodyKind.None, null, cancellationToken);
    }

    public Task<ApiResult<RemoveNodesResponse>> BulkDeleteNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/delete";
        var url = path;
        return SendAsync<RemoveNodesResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkNodesActionResponse>> BulkDisableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/disable";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkNodesActionResponse>> BulkEnableNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/enable";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkNodesActionResponse>> BulkResetNodesUsageAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/reset";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkNodesActionResponse>> BulkReconnectNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/reconnect";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }

    public Task<ApiResult<BulkNodesActionResponse>> BulkUpdateNodesAsync(BulkNodeSelection request, CancellationToken cancellationToken = default)
    {
        var path = @"/api/nodes/bulk/update";
        var url = path;
        return SendAsync<BulkNodesActionResponse>(HttpMethod.Post, url, request, RequestBodyKind.Json, null, cancellationToken);
    }
}
