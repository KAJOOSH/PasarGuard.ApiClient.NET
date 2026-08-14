using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<FinalMaskUdpType>))]
public enum FinalMaskUdpType
{
    [EnumMember(Value = "header-custom")]
    HeaderCustom,
    [EnumMember(Value = "mkcp-legacy")]
    MkcpLegacy,
    [EnumMember(Value = "noise")]
    Noise,
    [EnumMember(Value = "salamander")]
    Salamander,
    [EnumMember(Value = "sudoku")]
    Sudoku,
    [EnumMember(Value = "xdns")]
    Xdns,
    [EnumMember(Value = "xicmp")]
    Xicmp,
    [EnumMember(Value = "realm")]
    Realm,
    [EnumMember(Value = "header-dns")]
    HeaderDns,
    [EnumMember(Value = "header-dtls")]
    HeaderDtls,
    [EnumMember(Value = "header-srtp")]
    HeaderSrtp,
    [EnumMember(Value = "header-utp")]
    HeaderUtp,
    [EnumMember(Value = "header-wechat")]
    HeaderWechat,
    [EnumMember(Value = "header-wireguard")]
    HeaderWireguard,
    [EnumMember(Value = "mkcp-original")]
    MkcpOriginal,
    [EnumMember(Value = "mkcp-aes128gcm")]
    MkcpAes128gcm
}
