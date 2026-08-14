using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record AdminsSimpleResponse
{
    [JsonPropertyName("admins")]
    public required IReadOnlyList<AdminSimple> Admins { get; init; }

    [JsonPropertyName("total")]
    public required long Total { get; init; }
}
