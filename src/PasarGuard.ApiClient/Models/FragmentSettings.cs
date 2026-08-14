using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record FragmentSettings
{
    [JsonPropertyName("xray")]
    public XrayFragmentSettings? Xray { get; init; }

    [JsonPropertyName("sing_box")]
    public SingBoxFragmentSettings? SingBox { get; init; }
}
