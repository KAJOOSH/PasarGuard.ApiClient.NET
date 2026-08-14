using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeCoreUpdate
{
    [JsonPropertyName("core_version")]
    public string CoreVersion { get; init; } = "latest";
}
