using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserSubscriptionUpdateList
{
    [JsonPropertyName("updates")]
    public IReadOnlyList<UserSubscriptionUpdateSchema>? Updates { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
