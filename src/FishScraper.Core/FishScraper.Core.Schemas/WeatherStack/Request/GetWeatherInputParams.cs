namespace FishScraper.Core.Schemas.WeatherStack.Request;

public abstract record GetWeatherInputParams
{
    public required decimal Latitude { get; init; }
    public required decimal Longitude { get; init; }
    public WeatherStackUnitsEnum Unit { get; init; } = WeatherStackUnitsEnum.Metric;
}