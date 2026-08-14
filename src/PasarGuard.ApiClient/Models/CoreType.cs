using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<CoreType>))]
public enum CoreType
{
    [EnumMember(Value = "xray")]
    Xray,
    [EnumMember(Value = "wg")]
    Wg,
    [EnumMember(Value = "mtproto")]
    Mtproto,
    [EnumMember(Value = "singbox")]
    Singbox
}
