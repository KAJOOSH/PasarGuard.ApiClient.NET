using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Webhook
{
    [JsonPropertyName("enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName("webhooks")]
    public IReadOnlyList<WebhookInfo> Webhooks { get; init; } = [];

    [JsonPropertyName("days_left")]
    public IReadOnlyList<long> DaysLeft { get; init; } = [];

    [JsonPropertyName("usage_percent")]
    public IReadOnlyList<long> UsagePercent { get; init; } = [];

    [JsonPropertyName("timeout")]
    public required long Timeout { get; init; }

    [JsonPropertyName("recurrent")]
    public required long Recurrent { get; init; }

    [JsonPropertyName("proxy_url")]
    public string? ProxyUrl { get; init; }
}
