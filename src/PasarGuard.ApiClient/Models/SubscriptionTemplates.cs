using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SubscriptionTemplates
{
    [JsonPropertyName("xray")]
    public long? Xray { get; init; }
}
