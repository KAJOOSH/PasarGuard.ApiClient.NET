using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<Language>))]
public enum Language
{
    [EnumMember(Value = "fa")]
    Fa,
    [EnumMember(Value = "en")]
    En,
    [EnumMember(Value = "ru")]
    Ru,
    [EnumMember(Value = "zh")]
    Zh
}
