namespace FishScraper.Core.Schemas.WeatherStack;

public sealed record WeatherStackResponse
{
    public required WeatherStackRequest Request { get; init; }
    public required WeatherStackLocation Location { get; init; }
    public required WeatherStackCurrent Current { get; init; }
}
