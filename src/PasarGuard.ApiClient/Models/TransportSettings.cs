using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record TransportSettings
{
    [JsonPropertyName("xhttp_settings")]
    public XHttpSettings? XhttpSettings { get; init; }

    [JsonPropertyName("grpc_settings")]
    public GRPCSettings? GrpcSettings { get; init; }

    [JsonPropertyName("kcp_settings")]
    public KCPSettings? KcpSettings { get; init; }

    [JsonPropertyName("tcp_settings")]
    public TcpSettings? TcpSettings { get; init; }

    [JsonPropertyName("websocket_settings")]
    public WebSocketSettings? WebsocketSettings { get; init; }
}
