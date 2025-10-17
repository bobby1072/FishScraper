using System.Text.Json.Serialization;

namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackAirQuality
{
    public string? Co { get; init; }

    [JsonPropertyName("no2")]
    public string? No2 { get; init; }

    [JsonPropertyName("o3")]
    public string? O3 { get; init; }

    [JsonPropertyName("so2")]
    public string? So2 { get; init; }

    [JsonPropertyName("pm2_5")]
    public string? Pm25 { get; init; }

    [JsonPropertyName("pm10")]
    public string? Pm10 { get; init; }

    [JsonPropertyName("us-epa-index")]
    public string? UsEpaIndex { get; init; }

    [JsonPropertyName("gb-defra-index")]
    public string? GbDefraIndex { get; init; }
}
