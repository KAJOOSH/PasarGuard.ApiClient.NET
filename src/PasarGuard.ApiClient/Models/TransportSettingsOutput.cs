using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record TransportSettingsOutput
{
    [JsonPropertyName(@"xhttp_settings")]
    public XHttpSettingsOutput? XhttpSettings { get; init; }

    [JsonPropertyName(@"grpc_settings")]
    public GRPCSettings? GrpcSettings { get; init; }

    [JsonPropertyName(@"kcp_settings")]
    public KCPSettings? KcpSettings { get; init; }

    [JsonPropertyName(@"tcp_settings")]
    public TcpSettings? TcpSettings { get; init; }

    [JsonPropertyName(@"websocket_settings")]
    public WebSocketSettings? WebsocketSettings { get; init; }
}
