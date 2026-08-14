using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ProxyHostSecurity>))]
public enum ProxyHostSecurity
{
    [EnumMember(Value = "inbound_default")]
    InboundDefault,
    [EnumMember(Value = "none")]
    None,
    [EnumMember(Value = "tls")]
    Tls
}
