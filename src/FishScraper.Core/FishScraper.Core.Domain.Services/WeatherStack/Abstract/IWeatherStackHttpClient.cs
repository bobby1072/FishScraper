namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

internal interface IWeatherStackHttpClient
{
    Task GetCurrentWeatherAsync(decimal latitude, decimal longitude, CancellationToken ct = default);
}