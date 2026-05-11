
namespace PasarGuard.ApiClient.Internal;

internal static class UrlEncoding
{
    public static string EncodePathSegment(object value)
    {
        return Uri.EscapeDataString(ValueFormatter.Format(value));
    }
}
