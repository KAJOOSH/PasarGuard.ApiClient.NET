using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Conflict
{
    [JsonPropertyName("detail")]
    public string Detail { get; init; } = "Entity already exists";
}
