using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record ValidationError
{
    [JsonPropertyName(@"loc")]
    public required List<object> Loc { get; init; }

    [JsonPropertyName(@"msg")]
    public required string Msg { get; init; }

    [JsonPropertyName(@"type")]
    public required string Type { get; init; }

    [JsonPropertyName(@"input")]
    public object? Input { get; init; }

    [JsonPropertyName(@"ctx")]
    public Dictionary<string, object?>? Ctx { get; init; }
}
