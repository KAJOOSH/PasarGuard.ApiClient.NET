using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Brutal
{
    [JsonPropertyName("enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName("up_mbps")]
    public required long UpMbps { get; init; }

    [JsonPropertyName("down_mbps")]
    public required long DownMbps { get; init; }
}
