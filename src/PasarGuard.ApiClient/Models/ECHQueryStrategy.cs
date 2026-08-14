using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ECHQueryStrategy>))]
public enum ECHQueryStrategy
{
    [EnumMember(Value = "none")]
    None,
    [EnumMember(Value = "half")]
    Half,
    [EnumMember(Value = "full")]
    Full
}
