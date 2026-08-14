using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record MuxsettingsInput
{
    [JsonPropertyName("sing_box")]
    public SingBoxMuxSettings? SingBox { get; init; }

    [JsonPropertyName("clash")]
    public ClashMuxSettings? Clash { get; init; }

    [JsonPropertyName("xray")]
    public XraymuxsettingsInput? Xray { get; init; }
}
