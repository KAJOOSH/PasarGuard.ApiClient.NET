using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<ProxyHostFingerprint>))]
public enum ProxyHostFingerprint
{
    [EnumMember(Value = @"")]
    Empty,
    [EnumMember(Value = @"chrome")]
    Chrome,
    [EnumMember(Value = @"firefox")]
    Firefox,
    [EnumMember(Value = @"safari")]
    Safari,
    [EnumMember(Value = @"ios")]
    Ios,
    [EnumMember(Value = @"android")]
    Android,
    [EnumMember(Value = @"edge")]
    Edge,
    [EnumMember(Value = @"360")]
    Value360,
    [EnumMember(Value = @"qq")]
    Qq,
    [EnumMember(Value = @"random")]
    Random,
    [EnumMember(Value = @"randomized")]
    Randomized,
    [EnumMember(Value = @"randomizednoalpn")]
    Randomizednoalpn,
    [EnumMember(Value = @"unsafe")]
    Unsafe
}
