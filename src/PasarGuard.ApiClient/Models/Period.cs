using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<Period>))]
public enum Period
{
    [EnumMember(Value = "minute")]
    Minute,
    [EnumMember(Value = "hour")]
    Hour,
    [EnumMember(Value = "day")]
    Day,
    [EnumMember(Value = "month")]
    Month
}
