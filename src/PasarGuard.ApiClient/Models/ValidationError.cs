using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ValidationError
{
    [JsonPropertyName("loc")]
    public required IReadOnlyList<JsonElement> Loc { get; init; }

    [JsonPropertyName("msg")]
    public required string Msg { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("input")]
    public JsonElement? Input { get; init; }

    [JsonPropertyName("ctx")]
    public JsonElement? Ctx { get; init; }
}
