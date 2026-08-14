using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<XUDP>))]
public enum XUDP
{
    [EnumMember(Value = "reject")]
    Reject,
    [EnumMember(Value = "allow")]
    Allow,
    [EnumMember(Value = "skip")]
    Skip
}
