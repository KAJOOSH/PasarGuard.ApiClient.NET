
using System.Net;

namespace PasarGuard.ApiClient.Core;

public sealed record ApiResult
{
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public ApiError? Error { get; init; }

    public static ApiResult Success(HttpStatusCode statusCode)
    {
        return new ApiResult { IsSuccess = true, StatusCode = statusCode };
    }

    public static ApiResult Failure(ApiError error)
    {
        return new ApiResult { IsSuccess = false, StatusCode = error.StatusCode, Error = error };
    }
}

public sealed record ApiResult<T>
{
    public bool IsSuccess { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public T? Value { get; init; }
    public ApiError? Error { get; init; }

    public static ApiResult<T> Success(T? value, HttpStatusCode statusCode)
    {
        return new ApiResult<T> { IsSuccess = true, StatusCode = statusCode, Value = value };
    }

    public static ApiResult<T> Failure(ApiError error)
    {
        return new ApiResult<T> { IsSuccess = false, StatusCode = error.StatusCode, Error = error };
    }
}
