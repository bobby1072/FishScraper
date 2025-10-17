using FishScraper.Core.Schemas.WeatherStack.Response;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

internal interface IWeatherStackHttpClient
{
    Task<WeatherStackResponse> GetCurrentWeatherAsync(decimal latitude, decimal longitude, CancellationToken ct = default);
}