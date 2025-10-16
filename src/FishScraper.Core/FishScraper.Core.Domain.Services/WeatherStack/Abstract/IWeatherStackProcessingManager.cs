using FishScraper.Core.Schemas.WeatherStack;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

public interface IWeatherStackProcessingManager
{
    Task<WeatherStackResponse> GetCurrentWeatherAsync(GetCurrentWeatherInputParams input, CancellationToken cancellationToken = default);
}