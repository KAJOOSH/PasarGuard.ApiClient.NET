using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record GroupCreate
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("inbound_tags")]
    public required IReadOnlyList<string> InboundTags { get; init; }

    [JsonPropertyName("is_disabled")]
    public bool IsDisabled { get; init; } = false;
}
