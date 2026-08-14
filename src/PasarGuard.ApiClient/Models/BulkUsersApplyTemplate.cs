using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record BulkUsersApplyTemplate
{
    [JsonPropertyName("user_template_id")]
    public required long UserTemplateId { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("ids")]
    public IReadOnlyList<long>? Ids { get; init; }
}
