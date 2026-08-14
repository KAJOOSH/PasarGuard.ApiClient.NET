using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkAdminSelection
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<long>? Ids { get; init; }
}
