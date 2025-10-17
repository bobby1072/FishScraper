using System.Collections.Generic;

namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackForecast
{
    public Dictionary<string, WeatherStackDailyForecast> DailyForecasts { get; init; } = new();
}