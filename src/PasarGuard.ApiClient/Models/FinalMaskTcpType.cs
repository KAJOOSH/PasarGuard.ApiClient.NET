using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Models;

[JsonConverter(typeof(PasarGuardEnumJsonConverter<FinalMaskTcpType>))]
public enum FinalMaskTcpType
{
    [EnumMember(Value = "header-custom")]
    HeaderCustom,
    [EnumMember(Value = "fragment")]
    Fragment,
    [EnumMember(Value = "sudoku")]
    Sudoku,
    [EnumMember(Value = "xmc")]
    Xmc
}
