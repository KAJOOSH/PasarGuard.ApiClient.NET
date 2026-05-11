using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record SubFormatEnable
{
    [JsonPropertyName(@"links")]
    public bool Links { get; init; } = true;

    [JsonPropertyName(@"links_base64")]
    public bool LinksBase64 { get; init; } = true;

    [JsonPropertyName(@"xray")]
    public bool Xray { get; init; } = true;

    [JsonPropertyName(@"wireguard")]
    public bool Wireguard { get; init; } = true;

    [JsonPropertyName(@"sing_box")]
    public bool SingBox { get; init; } = true;

    [JsonPropertyName(@"clash")]
    public bool Clash { get; init; } = true;

    [JsonPropertyName(@"clash_meta")]
    public bool ClashMeta { get; init; } = true;

    [JsonPropertyName(@"outline")]
    public bool Outline { get; init; } = true;
}
