using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<DataLimitResetStrategy>))]
public enum DataLimitResetStrategy
{
    [EnumMember(Value = @"no_reset")]
    NoReset,
    [EnumMember(Value = @"day")]
    Day,
    [EnumMember(Value = @"week")]
    Week,
    [EnumMember(Value = @"month")]
    Month,
    [EnumMember(Value = @"year")]
    Year
}
