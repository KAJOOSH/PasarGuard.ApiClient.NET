using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<XHttpModes>))]
public enum XHttpModes
{
    [EnumMember(Value = "auto")]
    Auto,
    [EnumMember(Value = "packet-up")]
    PacketUp,
    [EnumMember(Value = "stream-up")]
    StreamUp,
    [EnumMember(Value = "stream-one")]
    StreamOne
}
