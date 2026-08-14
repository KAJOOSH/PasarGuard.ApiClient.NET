using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record RoleFeatures
{
    [JsonPropertyName("can_use_reset_strategy")]
    public bool CanUseResetStrategy { get; init; } = true;

    [JsonPropertyName("can_use_next_plan")]
    public bool CanUseNextPlan { get; init; } = true;
}
