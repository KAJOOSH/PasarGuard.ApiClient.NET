using System.Net;
using Microsoft.Extensions.Logging.Abstractions;
using PasarGuard.ApiClient.Clients;
using PasarGuard.ApiClient.Models;

namespace PasarGuard.ApiClient.Tests;

public sealed class RequestConstructionTests
{
    [Fact]
    public async Task AdminTokenUsesFormUrlEncodedBody()
    {
        var handler = new RecordingHandler(_ => JsonResponse("{\"access_token\":\"token\",\"token_type\":\"bearer\"}"));
        var client = new AdminClient(CreateHttpClient(handler), NullLogger<AdminClient>.Instance);

        var result = await client.AdminTokenAsync(new BodyAdminToken
        {
            Username = "admin@example.com",
            Password = "p&ss word"
        });

        Assert.True(result.IsSuccess);
        Assert.Equal(HttpMethod.Post, handler.Method);
        Assert.Equal("application/x-www-form-urlencoded", handler.ContentType);
        Assert.Contains("username=admin%40example.com", handler.Body, StringComparison.Ordinal);
        Assert.Contains("password=p%26ss+word", handler.Body, StringComparison.Ordinal);
    }

    [Fact]
    public async Task ApiKeyPatchUsesEncodedPathQueryAndJsonEnum()
    {
        var handler = new RecordingHandler(_ => new HttpResponseMessage(HttpStatusCode.NoContent));
        var client = new ApiKeysClient(CreateHttpClient(handler), NullLogger<ApiKeysClient>.Instance);

        var result = await client.ModifyApiKeyAsync(42, new APIKeyUpdate
        {
            Name = "automation",
            Status = APIKeyStatus.Disabled
        });

        Assert.True(result.IsSuccess);
        Assert.Equal(HttpMethod.Patch, handler.Method);
        Assert.Equal("/api/api_key/42", handler.RequestUri!.AbsolutePath);
        Assert.Equal("application/json", handler.ContentType);
        Assert.Contains("\"name\":\"automation\"", handler.Body, StringComparison.Ordinal);
        Assert.Contains("\"status\":\"disabled\"", handler.Body, StringComparison.Ordinal);
        Assert.DoesNotContain("\"note\"", handler.Body, StringComparison.Ordinal);
    }

    [Fact]
    public async Task SubscriptionHeadReturnsResponseHeaders()
    {
        var handler = new RecordingHandler(request =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.TryAddWithoutValidation("subscription-userinfo", "upload=1; download=2");
            return response;
        });
        var client = new SubscriptionClient(CreateHttpClient(handler), NullLogger<SubscriptionClient>.Instance);

        var result = await client.UserSubscriptionHeadersAsync("subscription-token", "PasarGuard-Test");

        Assert.True(result.IsSuccess);
        Assert.Equal(HttpMethod.Head, handler.Method);
        Assert.Equal("PasarGuard-Test", handler.Headers["user-agent"].Single());
        Assert.Equal("upload=1; download=2", result.Headers["subscription-userinfo"].Single());
    }

    [Fact]
    public async Task HwidPathSegmentIsEscaped()
    {
        var handler = new RecordingHandler(_ => new HttpResponseMessage(HttpStatusCode.NoContent));
        var client = new UserHwidClient(CreateHttpClient(handler), NullLogger<UserHwidClient>.Instance);

        await client.DeleteUserHwidAsync(7, "device/value");

        Assert.Equal("/api/user/7/hwids/device%2Fvalue", handler.RequestUri!.AbsolutePath);
    }

    private static HttpClient CreateHttpClient(HttpMessageHandler handler)
    {
        return new HttpClient(handler) { BaseAddress = new Uri("https://pasarguard.test") };
    }

    private static HttpResponseMessage JsonResponse(string json)
    {
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
        };
    }

    private sealed class RecordingHandler(Func<HttpRequestMessage, HttpResponseMessage> responder) : HttpMessageHandler
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
            Headers = request.Headers.ToDictionary(header => header.Key, header => (IReadOnlyList<string>)header.Value.ToArray(), StringComparer.OrdinalIgnoreCase);
            return responder(request);
        }
    }
}
