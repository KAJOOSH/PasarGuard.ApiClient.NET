using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record XHttpSettingsInput
{
    [JsonPropertyName(@"mode")]
    public XHttpModes? Mode { get; init; }

    [JsonPropertyName(@"no_grpc_header")]
    public bool? NoGrpcHeader { get; init; }

    [JsonPropertyName(@"x_padding_bytes")]
    public object? XPaddingBytes { get; init; }

    [JsonPropertyName(@"x_padding_obfs_mode")]
    public bool? XPaddingObfsMode { get; init; }

    [JsonPropertyName(@"x_padding_key")]
    public string? XPaddingKey { get; init; }

    [JsonPropertyName(@"x_padding_header")]
    public string? XPaddingHeader { get; init; }

    [JsonPropertyName(@"x_padding_placement")]
    public string? XPaddingPlacement { get; init; }

    [JsonPropertyName(@"x_padding_method")]
    public string? XPaddingMethod { get; init; }

    [JsonPropertyName(@"uplink_http_method")]
    public string? UplinkHttpMethod { get; init; }

    [JsonPropertyName(@"session_placement")]
    public string? SessionPlacement { get; init; }

    [JsonPropertyName(@"session_key")]
    public string? SessionKey { get; init; }

    [JsonPropertyName(@"seq_placement")]
    public string? SeqPlacement { get; init; }

    [JsonPropertyName(@"seq_key")]
    public string? SeqKey { get; init; }

    [JsonPropertyName(@"uplink_data_placement")]
    public string? UplinkDataPlacement { get; init; }

    [JsonPropertyName(@"uplink_data_key")]
    public string? UplinkDataKey { get; init; }

    [JsonPropertyName(@"uplink_chunk_size")]
    public long? UplinkChunkSize { get; init; }

    [JsonPropertyName(@"sc_max_each_post_bytes")]
    public object? ScMaxEachPostBytes { get; init; }

    [JsonPropertyName(@"sc_min_posts_interval_ms")]
    public object? ScMinPostsIntervalMs { get; init; }

    [JsonPropertyName(@"xmux")]
    public XMuxSettingsInput? Xmux { get; init; }

    [JsonPropertyName(@"download_settings")]
    public long? DownloadSettings { get; init; }
}
