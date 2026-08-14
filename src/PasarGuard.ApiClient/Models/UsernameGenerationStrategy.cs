using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<UsernameGenerationStrategy>))]
public enum UsernameGenerationStrategy
{
    [EnumMember(Value = "random")]
    Random,
    [EnumMember(Value = "sequence")]
    Sequence
}
