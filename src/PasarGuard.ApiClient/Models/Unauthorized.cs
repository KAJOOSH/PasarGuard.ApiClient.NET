using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Unauthorized
{
    [JsonPropertyName("detail")]
    public string Detail { get; init; } = "Not authenticated";
}
