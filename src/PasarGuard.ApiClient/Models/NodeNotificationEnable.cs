using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeNotificationEnable
{
    [JsonPropertyName("create")]
    public bool Create { get; init; } = true;

    [JsonPropertyName("modify")]
    public bool Modify { get; init; } = true;

    [JsonPropertyName("delete")]
    public bool Delete { get; init; } = true;

    [JsonPropertyName("connect")]
    public bool Connect { get; init; } = true;

    [JsonPropertyName("recovered")]
    public bool Recovered { get; init; } = true;

    [JsonPropertyName("error")]
    public bool Error { get; init; } = true;

    [JsonPropertyName("limited")]
    public bool Limited { get; init; } = true;

    [JsonPropertyName("reset_usage")]
    public bool ResetUsage { get; init; } = true;
}
