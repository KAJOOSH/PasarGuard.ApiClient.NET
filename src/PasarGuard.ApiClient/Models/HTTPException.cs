using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HTTPException
{
    [JsonPropertyName("detail")]
    public required string Detail { get; init; }
}
