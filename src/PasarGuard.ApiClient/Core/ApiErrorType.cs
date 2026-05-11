
namespace PasarGuard.ApiClient.Core;

public enum ApiErrorType
{
    BadRequest,
    Unauthorized,
    Forbidden,
    NotFound,
    Conflict,
    Validation,
    ServerError,
    Timeout,
    Canceled,
    Network,
    Serialization,
    Unknown
}
