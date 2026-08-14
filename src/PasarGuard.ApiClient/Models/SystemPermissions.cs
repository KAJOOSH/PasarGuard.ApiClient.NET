using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record SystemPermissions
{
    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }
}
