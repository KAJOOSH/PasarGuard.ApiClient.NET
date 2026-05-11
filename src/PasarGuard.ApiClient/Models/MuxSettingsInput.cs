using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record MuxSettingsInput
{
    [JsonPropertyName(@"sing_box")]
    public SingBoxMuxSettings? SingBox { get; init; }

    [JsonPropertyName(@"clash")]
    public ClashMuxSettings? Clash { get; init; }

    [JsonPropertyName(@"xray")]
    public XrayMuxSettingsInput? Xray { get; init; }
}
