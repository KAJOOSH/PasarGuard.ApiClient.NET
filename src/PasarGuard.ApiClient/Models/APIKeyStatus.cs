using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<APIKeyStatus>))]
public enum APIKeyStatus
{
    [EnumMember(Value = "active")]
    Active,
    [EnumMember(Value = "disabled")]
    Disabled
}
