using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<PermissionScope>))]
public enum PermissionScope
{
    [EnumMember(Value = "0")]
    Value0,
    [EnumMember(Value = "1")]
    Value1,
    [EnumMember(Value = "2")]
    Value2
}
