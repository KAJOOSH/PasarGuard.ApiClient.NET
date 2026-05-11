using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<NodeStatus>))]
public enum NodeStatus
{
    [EnumMember(Value = @"connected")]
    Connected,
    [EnumMember(Value = @"connecting")]
    Connecting,
    [EnumMember(Value = @"error")]
    Error,
    [EnumMember(Value = @"disabled")]
    Disabled,
    [EnumMember(Value = @"limited")]
    Limited
}
