using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<UserStatusCreate>))]
public enum UserStatusCreate
{
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "on_hold")]
    OnHold
}
