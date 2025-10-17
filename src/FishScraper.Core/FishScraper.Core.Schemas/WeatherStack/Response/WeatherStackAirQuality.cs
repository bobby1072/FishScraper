using System.Text.Json.Serialization;

namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackAirQuality
{
    public required string Co { get; init; }

    [JsonPropertyName("no2")]
    public required string No2 { get; init; }

    [JsonPropertyName("o3")]
    public required string O3 { get; init; }

    [JsonPropertyName("so2")]
    public required string So2 { get; init; }

    [JsonPropertyName("pm2_5")]
    public required string Pm25 { get; init; }

    [JsonPropertyName("pm10")]
    public required string Pm10 { get; init; }

    [JsonPropertyName("us-epa-index")]
    public required string UsEpaIndex { get; init; }

    [JsonPropertyName("gb-defra-index")]
    public required string GbDefraIndex { get; init; }
}
