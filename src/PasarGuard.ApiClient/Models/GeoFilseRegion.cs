using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<GeoFilseRegion>))]
public enum GeoFilseRegion
{
    [EnumMember(Value = @"iran")]
    Iran,
    [EnumMember(Value = @"china")]
    China,
    [EnumMember(Value = @"russia")]
    Russia
}
