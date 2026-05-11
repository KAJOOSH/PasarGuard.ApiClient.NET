using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record Webhook
{
    [JsonPropertyName(@"enable")]
    public bool Enable { get; init; } = false;

    [JsonPropertyName(@"webhooks")]
    public List<WebhookInfo> Webhooks { get; init; } = new();

    [JsonPropertyName(@"days_left")]
    public List<long> DaysLeft { get; init; } = new();

    [JsonPropertyName(@"usage_percent")]
    public List<long> UsagePercent { get; init; } = new();

    [JsonPropertyName(@"timeout")]
    public required long Timeout { get; init; }

    [JsonPropertyName(@"recurrent")]
    public required long Recurrent { get; init; }

    [JsonPropertyName(@"proxy_url")]
    public string? ProxyUrl { get; init; }
}
