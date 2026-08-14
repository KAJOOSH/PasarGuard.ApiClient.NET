using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UsersPermissions
{
    [JsonPropertyName("create")]
    public JsonElement? Create { get; init; }

    [JsonPropertyName("read")]
    public JsonElement? Read { get; init; }

    [JsonPropertyName("read_simple")]
    public JsonElement? ReadSimple { get; init; }

    [JsonPropertyName("update")]
    public JsonElement? Update { get; init; }

    [JsonPropertyName("delete")]
    public JsonElement? Delete { get; init; }

    [JsonPropertyName("reset_usage")]
    public JsonElement? ResetUsage { get; init; }

    [JsonPropertyName("revoke_sub")]
    public JsonElement? RevokeSub { get; init; }

    [JsonPropertyName("set_owner")]
    public JsonElement? SetOwner { get; init; }

    [JsonPropertyName("activate_next_plan")]
    public JsonElement? ActivateNextPlan { get; init; }
}
