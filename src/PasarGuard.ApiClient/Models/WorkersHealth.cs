using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed partial record WorkersHealth
{
    [JsonPropertyName(@"scheduler")]
    public required WorkerHealth Scheduler { get; init; }

    [JsonPropertyName(@"node")]
    public required WorkerHealth Node { get; init; }
}
