using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<UsageTable>))]
public enum UsageTable
{
    [EnumMember(Value = "node_user_usages")]
    NodeUserUsages,
    [EnumMember(Value = "node_usages")]
    NodeUsages
}
