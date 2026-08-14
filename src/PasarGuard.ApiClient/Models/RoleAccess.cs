using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RoleAccess
{
    [JsonPropertyName("require_template")]
    public bool RequireTemplate { get; init; } = false;

    [JsonPropertyName("allowed_template_ids")]
    public IReadOnlyList<long>? AllowedTemplateIds { get; init; }

    [JsonPropertyName("allowed_group_ids")]
    public IReadOnlyList<long>? AllowedGroupIds { get; init; }
}
