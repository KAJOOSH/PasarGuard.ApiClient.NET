namespace PasarGuard.ApiClient.Core;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class ApiEndpointAttribute : Attribute
{
    public ApiEndpointAttribute(string method, string path, string operationId)
    {
        Method = method;
        Path = path;
        OperationId = operationId;
    }

    public string Method { get; }
    public string Path { get; }
    public string OperationId { get; }
}
