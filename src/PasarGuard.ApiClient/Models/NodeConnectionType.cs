using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<NodeConnectionType>))]
public enum NodeConnectionType
{
    [EnumMember(Value = "grpc")]
    Grpc,
    [EnumMember(Value = "rest")]
    Rest
}
