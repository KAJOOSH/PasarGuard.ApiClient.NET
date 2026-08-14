using System.Net;

namespace PasarGuard.ApiClient.Tests.Infrastructure;

internal sealed class RequestRecorder : HttpMessageHandler
{
    public HttpMethod? Method { get; private set; }
    public Uri? RequestUri { get; private set; }
    public string? Body { get; private set; }
    public string? ContentType { get; private set; }
    public IReadOnlyDictionary<string, IReadOnlyList<string>> Headers { get; private set; } = new Dictionary<string, IReadOnlyList<string>>();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Method = request.Method;
        RequestUri = request.RequestUri;
        Body = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
        ContentType = request.Content?.Headers.ContentType?.MediaType;
        Headers = request.Headers.ToDictionary(
            header => header.Key,
            header => (IReadOnlyList<string>)header.Value.ToArray(),
            StringComparer.OrdinalIgnoreCase);
        return new HttpResponseMessage(HttpStatusCode.NoContent);
    }
}
