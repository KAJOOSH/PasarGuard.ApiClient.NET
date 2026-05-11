
using System.Net;
using System.Text.Json;

namespace PasarGuard.ApiClient.Core;

internal static class ApiErrorFactory
{
    public static ApiError Create(HttpStatusCode statusCode, string reasonPhrase, string? responseContent)
    {
        return new ApiError
        {
            StatusCode = statusCode,
            ReasonPhrase = reasonPhrase,
            Message = ExtractMessage(responseContent) ?? CreateDefaultMessage(statusCode, reasonPhrase),
            ResponseContent = responseContent,
            Type = GetErrorType(statusCode)
        };
    }

    public static ApiError Create(ApiErrorType type, string message)
    {
        return new ApiError
        {
            StatusCode = 0,
            ReasonPhrase = type.ToString(),
            Message = message,
            Type = type
        };
    }

    private static string? ExtractMessage(string? responseContent)
    {
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            return null;
        }

        try
        {
            using var document = JsonDocument.Parse(responseContent);
            if (document.RootElement.ValueKind == JsonValueKind.Object && document.RootElement.TryGetProperty("detail", out var detail))
            {
                return detail.ValueKind switch
                {
                    JsonValueKind.String => detail.GetString(),
                    JsonValueKind.Array => "Validation error",
                    JsonValueKind.Object => detail.GetRawText(),
                    _ => detail.GetRawText()
                };
            }
        }
        catch (JsonException)
        {
            return responseContent;
        }

        return responseContent;
    }

    private static string CreateDefaultMessage(HttpStatusCode statusCode, string reasonPhrase)
    {
        return string.IsNullOrWhiteSpace(reasonPhrase) ? $"HTTP request failed with status code {(int)statusCode}." : reasonPhrase;
    }

    private static ApiErrorType GetErrorType(HttpStatusCode statusCode)
    {
        return statusCode switch
        {
            HttpStatusCode.BadRequest => ApiErrorType.BadRequest,
            HttpStatusCode.Unauthorized => ApiErrorType.Unauthorized,
            HttpStatusCode.Forbidden => ApiErrorType.Forbidden,
            HttpStatusCode.NotFound => ApiErrorType.NotFound,
            HttpStatusCode.Conflict => ApiErrorType.Conflict,
            HttpStatusCode.UnprocessableEntity => ApiErrorType.Validation,
            _ when (int)statusCode >= 500 => ApiErrorType.ServerError,
            _ => ApiErrorType.Unknown
        };
    }
}
