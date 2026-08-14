
using System.Net;

namespace PasarGuard.ApiClient.Core;

public sealed record ApiResult
{
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public ApiError? Error { get; init; }
    public IReadOnlyDictionary<string, IReadOnlyList<string>> Headers { get; init; } = ApiResponseHeaders.Empty;

    public static ApiResult Success(HttpStatusCode statusCode, IReadOnlyDictionary<string, IReadOnlyList<string>>? headers = null)
    {
        return new ApiResult { IsSuccess = true, StatusCode = statusCode, Headers = headers ?? ApiResponseHeaders.Empty };
    }

    public static ApiResult Failure(ApiError error, IReadOnlyDictionary<string, IReadOnlyList<string>>? headers = null)
    {
        return new ApiResult { IsSuccess = false, StatusCode = error.StatusCode, Error = error, Headers = headers ?? ApiResponseHeaders.Empty };
    }
}

public sealed record ApiResult<T>
{
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public T? Value { get; init; }
    public ApiError? Error { get; init; }
    public IReadOnlyDictionary<string, IReadOnlyList<string>> Headers { get; init; } = ApiResponseHeaders.Empty;

    public static ApiResult<T> Success(T? value, HttpStatusCode statusCode, IReadOnlyDictionary<string, IReadOnlyList<string>>? headers = null)
    {
        return new ApiResult<T> { IsSuccess = true, StatusCode = statusCode, Value = value, Headers = headers ?? ApiResponseHeaders.Empty };
    }

    public static ApiResult<T> Failure(ApiError error, IReadOnlyDictionary<string, IReadOnlyList<string>>? headers = null)
    {
        return new ApiResult<T> { IsSuccess = false, StatusCode = error.StatusCode, Error = error, Headers = headers ?? ApiResponseHeaders.Empty };
    }
}

internal static class ApiResponseHeaders
{
    public static IReadOnlyDictionary<string, IReadOnlyList<string>> Empty { get; } = new Dictionary<string, IReadOnlyList<string>>();
}
