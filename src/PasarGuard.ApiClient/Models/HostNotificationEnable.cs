using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record HostNotificationEnable
{
    [JsonPropertyName(@"create")]
    public bool Create { get; init; } = true;

    [JsonPropertyName(@"modify")]
    public bool Modify { get; init; } = true;

    [JsonPropertyName(@"delete")]
    public bool Delete { get; init; } = true;

    [JsonPropertyName(@"modify_hosts")]
    public bool ModifyHosts { get; init; } = true;
}
