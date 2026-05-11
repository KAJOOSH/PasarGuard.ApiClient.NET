using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record VlessSettings
{
    [JsonPropertyName(@"id")]
    public Guid? Id { get; init; }

    [JsonPropertyName(@"flow")]
    public XTLSFlows Flow { get; init; } = XTLSFlows.Empty;
}
