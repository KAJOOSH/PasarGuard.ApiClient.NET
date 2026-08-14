using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<UserStatus>))]
public enum UserStatus
{
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "disabled")]
    Disabled,
    [EnumMember(Value = "limited")]
    Limited,
    [EnumMember(Value = "expired")]
    Expired,
    [EnumMember(Value = "on_hold")]
    OnHold
}
