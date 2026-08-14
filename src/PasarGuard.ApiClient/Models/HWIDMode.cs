using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<HWIDMode>))]
public enum HWIDMode
{
    [EnumMember(Value = "disabled")]
    Disabled,
    [EnumMember(Value = "use_global")]
    UseGlobal,
    [EnumMember(Value = "override")]
    Override
}
