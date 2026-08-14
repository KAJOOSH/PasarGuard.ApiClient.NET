using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HwidsPermissions
{
    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }

    [JsonPropertyName("delete")]
    public JsonElement? Delete { get; init; }
}
