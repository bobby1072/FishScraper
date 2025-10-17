using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

public interface IWeatherStackProcessingManager
{
    Task<WeatherStackResponse> GetCurrentWeatherAsync(GetCurrentWeatherInputParams input, CancellationToken cancellationToken = default);
}