using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ProxyHostALPN>))]
public enum ProxyHostALPN
{
    [EnumMember(Value = @"http/1.1")]
    Http11,
    [EnumMember(Value = @"h2")]
    H2,
    [EnumMember(Value = @"h3")]
    H3
}
