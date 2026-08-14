using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record ExtraSettings
{
    [JsonPropertyName("method")]
    public ShadowsocksMethods? Method { get; init; } = ShadowsocksMethods.Chacha20IetfPoly1305;
}
