using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FinalMaskSudokuSettings
{
    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("ascii")]
    public string? Ascii { get; init; }

    [JsonPropertyName("customTable")]
    public string? CustomTable { get; init; }

    [JsonPropertyName("customTables")]
    public IReadOnlyList<string>? CustomTables { get; init; }

    [JsonPropertyName("paddingMin")]
    public long? PaddingMin { get; init; }

    [JsonPropertyName("paddingMax")]
    public long? PaddingMax { get; init; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement> AdditionalProperties { get; init; } = [];
}
