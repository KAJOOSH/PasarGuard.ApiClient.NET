using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record Forbidden
{
    [JsonPropertyName("detail")]
    public string Detail { get; init; } = "You are not allowed to ...";
}
