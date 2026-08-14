using System.Reflection;
using System.Text.Json;
using PasarGuard.ApiClient.Abstractions;
using PasarGuard.ApiClient.Core;

namespace PasarGuard.ApiClient.Tests;

public sealed class OpenApiCoverageTests
{
    private static readonly HashSet<string> HttpMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "get", "post", "put", "patch", "delete", "head", "options", "trace"
    };

    [Fact]
    public void ClientInterfacesCoverEveryOpenApiOperation()
    {
        using var document = LoadSpecification();
        var expected = document.RootElement.GetProperty("paths")
            .EnumerateObject()
            .SelectMany(path => path.Value.EnumerateObject()
                .Where(operation => HttpMethods.Contains(operation.Name))
                .Select(operation => $"{operation.Name.ToUpperInvariant()} {path.Name} {operation.Value.GetProperty("operationId").GetString()}"))
            .OrderBy(value => value, StringComparer.Ordinal)
            .ToArray();

        var actual = typeof(IPasarGuardApiClient).Assembly.GetTypes()
            .Where(type => type.IsInterface && type.Namespace == typeof(IPasarGuardApiClient).Namespace && type != typeof(IPasarGuardApiClient))
            .SelectMany(type => type.GetMethods())
            .Select(method => method.GetCustomAttribute<ApiEndpointAttribute>())
            .Where(attribute => attribute is not null)
            .Select(attribute => $"{attribute!.Method} {attribute.Path} {attribute.OperationId}")
            .OrderBy(value => value, StringComparer.Ordinal)
            .ToArray();

        Assert.Equal(204, expected.Length);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GeneratedModelsCoverEveryOpenApiSchema()
    {
        using var document = LoadSpecification();
        var expectedCount = document.RootElement.GetProperty("components").GetProperty("schemas").EnumerateObject().Count();
        var actualCount = typeof(IPasarGuardApiClient).Assembly.GetTypes().Count(type => type.Namespace == "PasarGuard.ApiClient.Models");

        Assert.Equal("5.2.1", document.RootElement.GetProperty("info").GetProperty("version").GetString());
        Assert.Equal(252, expectedCount);
        Assert.Equal(expectedCount, actualCount);
    }

    private static JsonDocument LoadSpecification()
    {
        return JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "openapi.json")));
    }
}
