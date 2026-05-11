using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record General
{
    [JsonPropertyName(@"default_flow")]
    public XTLSFlows DefaultFlow { get; init; } = XTLSFlows.Empty;

    [JsonPropertyName(@"default_method")]
    public ShadowsocksMethods DefaultMethod { get; init; } = ShadowsocksMethods.Chacha20IetfPoly1305;
}
