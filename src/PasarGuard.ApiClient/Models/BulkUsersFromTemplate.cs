using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUsersFromTemplate
{
    [JsonPropertyName("user_template_id")]
    public required long UserTemplateId { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("count")]
    public required long Count { get; init; }

    [JsonPropertyName("strategy")]
    public UsernameGenerationStrategy Strategy { get; init; } = UsernameGenerationStrategy.Random;

    [JsonPropertyName("start_number")]
    public long? StartNumber { get; init; }
}
