using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ClientTemplateType>))]
public enum ClientTemplateType
{
    [EnumMember(Value = @"clash_subscription")]
    ClashSubscription,
    [EnumMember(Value = @"xray_subscription")]
    XraySubscription,
    [EnumMember(Value = @"singbox_subscription")]
    SingboxSubscription,
    [EnumMember(Value = @"user_agent")]
    UserAgent,
    [EnumMember(Value = @"grpc_user_agent")]
    GrpcUserAgent
}
