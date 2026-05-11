using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ShadowsocksMethods>))]
public enum ShadowsocksMethods
{
    [EnumMember(Value = @"aes-128-gcm")]
    Aes128Gcm,
    [EnumMember(Value = @"aes-256-gcm")]
    Aes256Gcm,
    [EnumMember(Value = @"chacha20-ietf-poly1305")]
    Chacha20IetfPoly1305,
    [EnumMember(Value = @"xchacha20-poly1305")]
    Xchacha20Poly1305
}
