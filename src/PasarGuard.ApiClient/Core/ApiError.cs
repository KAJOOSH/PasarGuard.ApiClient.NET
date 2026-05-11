
using System.Net;

namespace PasarGuard.ApiClient.Core;

public sealed record ApiError
{
    public required HttpStatusCode StatusCode { get; init; }
    public required string ReasonPhrase { get; init; }
    public required string Message { get; init; }
    public string? ResponseContent { get; init; }
    public ApiErrorType Type { get; init; }
}
