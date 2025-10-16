namespace FishScraper.Core.Schemas.WeatherStack;

public sealed record WeatherStackAirQuality
{
    public required string Co { get; init; }
    public required string No2 { get; init; }
    public required string O3 { get; init; }
    public required string So2 { get; init; }
    public required string Pm2_5 { get; init; }
    public required string Pm10 { get; init; }
    public required string UsEpaIndex { get; init; }
    public required string GbDefraIndex { get; init; }
}
