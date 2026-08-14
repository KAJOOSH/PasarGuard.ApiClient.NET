using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<RunMethod>))]
public enum RunMethod
{
    [EnumMember(Value = "webhook")]
    Webhook,
    [EnumMember(Value = "long-polling")]
    LongPolling
}
