using FishScraper.Core.Schemas.WeatherStack;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

internal interface IWeatherStackHttpClient
{
    Task<WeatherStackResponse> GetCurrentWeatherAsync(decimal latitude, decimal longitude, CancellationToken ct = default);
}