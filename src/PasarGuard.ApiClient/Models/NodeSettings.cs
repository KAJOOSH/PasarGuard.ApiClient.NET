using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeSettings
{
    [JsonPropertyName("min_node_version")]
    public string MinNodeVersion { get; init; } = "v1.0.0";
}
