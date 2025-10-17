namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackDailyForecast
{
    public required string Date { get; init; }
    public int DateEpoch { get; init; }
    public required WeatherStackAstroResponse Astro { get; init; }
    public int Mintemp { get; init; }
    public int Maxtemp { get; init; }
    public int Avgtemp { get; init; }
    public int Totalsnow { get; init; }
    public double Sunhour { get; init; }
    public int UvIndex { get; init; }
    public required WeatherStackAirQualityResponse AirQuality { get; init; }
    public WeatherStackHourlyForecast[] Hourly { get; init; } = [];
}