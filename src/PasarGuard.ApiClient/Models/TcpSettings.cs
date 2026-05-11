using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record TcpSettings
{
    [JsonPropertyName(@"header")]
    public string Header { get; init; } = @"none";

    [JsonPropertyName(@"request")]
    public HTTPRequest? Request { get; init; }

    [JsonPropertyName(@"response")]
    public HTTPResponse? Response { get; init; }
}
