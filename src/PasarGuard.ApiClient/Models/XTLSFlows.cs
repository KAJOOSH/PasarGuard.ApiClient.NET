using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<XTLSFlows>))]
public enum XTLSFlows
{
    [EnumMember(Value = @"")]
    Empty,
    [EnumMember(Value = @"xtls-rprx-vision")]
    XtlsRprxVision,
    [EnumMember(Value = @"xtls-rprx-vision-udp443")]
    XtlsRprxVisionUdp443
}
