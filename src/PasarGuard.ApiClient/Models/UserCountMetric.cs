using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<UserCountMetric>))]
public enum UserCountMetric
{
    [EnumMember(Value = "online")]
    Online,
    [EnumMember(Value = "expired")]
    Expired,
    [EnumMember(Value = "limited")]
    Limited
}
