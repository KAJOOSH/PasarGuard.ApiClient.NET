using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<MultiplexProtocol>))]
public enum MultiplexProtocol
{
    [EnumMember(Value = "smux")]
    Smux,
    [EnumMember(Value = "yamux")]
    Yamux,
    [EnumMember(Value = "h2mux")]
    H2mux
}
