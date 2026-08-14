using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record UserStatusToggle
{
    [JsonPropertyName("disabled")]
    public required bool Disabled { get; init; }
}
