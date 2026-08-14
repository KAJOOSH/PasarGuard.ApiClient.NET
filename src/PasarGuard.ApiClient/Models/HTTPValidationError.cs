using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record HTTPValidationError
{
    [JsonPropertyName("detail")]
    public IReadOnlyList<ValidationError>? Detail { get; init; }
}
