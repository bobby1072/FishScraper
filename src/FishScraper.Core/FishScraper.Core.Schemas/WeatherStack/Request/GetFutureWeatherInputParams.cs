namespace FishScraper.Core.Schemas.WeatherStack.Request;

public sealed record GetFutureWeatherInputParams: GetWeatherInputParams
{
    public int ForecastDays { get; init; } = 1;
}