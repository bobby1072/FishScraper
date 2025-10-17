using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;

namespace FishScraper.Core.Domain.Services.WeatherStack.Abstract;

internal interface IWeatherStackHttpClient
{
    Task<WeatherStackCurrentResponse> GetCurrentWeatherAsync(decimal latitude, decimal longitude, WeatherStackUnitsEnum units, CancellationToken ct = default);
    Task<WeatherStackFutureResponse> GetFutureWeatherAsync(decimal latitude, decimal longitude, int forecastDays,
        WeatherStackUnitsEnum units, CancellationToken ct = default);
}