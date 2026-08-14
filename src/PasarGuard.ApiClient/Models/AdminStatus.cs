using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<AdminStatus>))]
public enum AdminStatus
{
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "disabled")]
    Disabled,
    [EnumMember(Value = "limited")]
    Limited
}
