using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<Platform>))]
public enum Platform
{
    [EnumMember(Value = @"android")]
    Android,
    [EnumMember(Value = @"ios")]
    Ios,
    [EnumMember(Value = @"windows")]
    Windows,
    [EnumMember(Value = @"macos")]
    Macos,
    [EnumMember(Value = @"linux")]
    Linux,
    [EnumMember(Value = @"appletv")]
    Appletv,
    [EnumMember(Value = @"androidtv")]
    Androidtv
}
