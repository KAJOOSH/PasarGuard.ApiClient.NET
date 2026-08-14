using System.Text.Json;
using System.Text.Json.Serialization;

namespace PasarGuard.ApiClient.Models;

public sealed record NodeGeoFilesUpdate
{
    [JsonPropertyName("region")]
    public GeoFilseRegion Region { get; init; } = GeoFilseRegion.Iran;
}
