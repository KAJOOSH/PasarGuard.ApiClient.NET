using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record General
{
    [JsonPropertyName("default_method")]
    public ShadowsocksMethods DefaultMethod { get; init; } = ShadowsocksMethods.Chacha20IetfPoly1305;

    [JsonPropertyName("custom_variables")]
    public IReadOnlyList<CustomVariable>? CustomVariables { get; init; }
}
