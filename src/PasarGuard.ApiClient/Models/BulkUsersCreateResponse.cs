using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUsersCreateResponse
{
    [JsonPropertyName("subscription_urls")]
    public IReadOnlyList<string>? SubscriptionUrls { get; init; }

    [JsonPropertyName("created")]
    public long Created { get; init; } = 0L;
}
