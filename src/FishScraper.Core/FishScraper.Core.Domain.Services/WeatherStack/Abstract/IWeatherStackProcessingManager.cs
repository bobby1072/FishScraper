using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

public interface IWeatherStackProcessingManager
{
    Task<WeatherStackFutureResponse> GetFutureWeatherAsync(GetFutureWeatherInputParams input,
        CancellationToken cancellationToken = default);
    Task<WeatherStackCurrentResponse> GetCurrentWeatherAsync(GetCurrentWeatherInputParams input, CancellationToken cancellationToken = default);
}