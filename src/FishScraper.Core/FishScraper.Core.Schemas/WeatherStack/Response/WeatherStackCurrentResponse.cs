namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackCurrentResponse
{
    public required WeatherStackRequestResponse Request { get; init; }
    public required WeatherStackLocationResponse Location { get; init; }
    public required WeatherStackCurrentData Current { get; init; }
}
