using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserHWIDListResponse
{
    [JsonPropertyName("hwids")]
    public required IReadOnlyList<UserHWIDResponse> Hwids { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }
}
