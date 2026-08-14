using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<FinalMaskQuicCongestion>))]
public enum FinalMaskQuicCongestion
{
    [EnumMember(Value = "reno")]
    Reno,
    [EnumMember(Value = "bbr")]
    Bbr,
    [EnumMember(Value = "brutal")]
    Brutal,
    [EnumMember(Value = "force-brutal")]
    ForceBrutal
}
