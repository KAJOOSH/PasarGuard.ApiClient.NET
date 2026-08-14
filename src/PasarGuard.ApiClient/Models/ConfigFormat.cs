using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ConfigFormat>))]
public enum ConfigFormat
{
    [EnumMember(Value = "links")]
    Links,
    [EnumMember(Value = "links_base64")]
    LinksBase64,
    [EnumMember(Value = "xray")]
    Xray,
    [EnumMember(Value = "wireguard")]
    Wireguard,
    [EnumMember(Value = "sing_box")]
    SingBox,
    [EnumMember(Value = "clash")]
    Clash,
    [EnumMember(Value = "clash_meta")]
    ClashMeta,
    [EnumMember(Value = "outline")]
    Outline,
    [EnumMember(Value = "block")]
    Block
}
