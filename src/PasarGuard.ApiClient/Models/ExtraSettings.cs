using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ExtraSettings
{
    [JsonPropertyName(@"flow")]
    public XTLSFlows? Flow { get; init; } = XTLSFlows.Empty;

    [JsonPropertyName(@"method")]
    public ShadowsocksMethods? Method { get; init; } = ShadowsocksMethods.Chacha20IetfPoly1305;
}
