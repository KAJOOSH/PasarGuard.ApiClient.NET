using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record UsersSimpleResponse
{
    [JsonPropertyName(@"users")]
    public required List<UserSimple> Users { get; init; }

    [JsonPropertyName(@"total")]
    public required long Total { get; init; }
}
