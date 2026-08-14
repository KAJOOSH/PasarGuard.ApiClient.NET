using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUsersSetOwner
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<long>? Ids { get; init; }

    [JsonPropertyName("admin_username")]
    public required string AdminUsername { get; init; }
}
