using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record GroupModify
{
    [JsonPropertyName(@"name")]
    public required string Name { get; init; }

    [JsonPropertyName(@"inbound_tags")]
    public List<string>? InboundTags { get; init; } = new();

    [JsonPropertyName(@"is_disabled")]
    public bool IsDisabled { get; init; } = false;
}
