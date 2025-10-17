namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackFutureResponse
{
    public required WeatherStackRequestResponse Request { get; init; }
    public required WeatherStackLocationResponse Location { get; init; }
    public required WeatherStackCurrentData Current { get; init; }
    public required WeatherStackForecast Forecast { get; init; }
}