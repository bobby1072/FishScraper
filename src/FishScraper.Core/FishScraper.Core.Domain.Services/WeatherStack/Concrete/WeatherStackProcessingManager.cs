using System.Net;
using BT.Common.Api.Helpers.Exceptions;
using FishScraper.Core.Common.Helpers;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;
using Microsoft.Extensions.Logging;

namespace FishScraper.Core.Domain.Services.WeatherStack.Concrete;

internal sealed class WeatherStackProcessingManager: IWeatherStackProcessingManager
{
    private readonly IWeatherStackHttpClient _weatherHttpClient;
    private readonly ILogger<WeatherStackProcessingManager> _logger;
    public WeatherStackProcessingManager(IWeatherStackHttpClient weatherHttpClient, ILogger<WeatherStackProcessingManager> logger)
    {
        _weatherHttpClient = weatherHttpClient;
        _logger = logger;
    }
    public async Task<WeatherStackFutureResponse> GetFutureWeatherAsync(GetFutureWeatherInputParams input, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting GetFutureWeather process...");

        if (!WeatherHelper.IsValidLatitude(input.Latitude) || !WeatherHelper.IsValidLongitude(input.Longitude))
        {
            throw new ApiClientException(HttpStatusCode.BadRequest, "Invalid Latitude or Longitude");
        }

        if (input.ForecastDays is > 7 or < 1)
        {
            throw new ApiClientException(HttpStatusCode.BadRequest, "Forecast days must be between 1 and 7");
        }
        var responseFromApi = await _weatherHttpClient.GetFutureWeatherAsync(input.Latitude, input.Longitude, input.ForecastDays, input.Unit, cancellationToken);
        
        _logger.LogInformation("GetFutureWeather process finished...");
        
        return responseFromApi;
    }
    public async Task<WeatherStackCurrentResponse> GetCurrentWeatherAsync(GetCurrentWeatherInputParams input, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting GetCurrentWeather process...");

        if (!WeatherHelper.IsValidLatitude(input.Latitude) || !WeatherHelper.IsValidLongitude(input.Longitude))
        {
            throw new ApiClientException(HttpStatusCode.BadRequest, "Invalid Latitude or Longitude");
        }
        
        var responseFromApi = await _weatherHttpClient.GetCurrentWeatherAsync(input.Latitude, input.Longitude, input.Unit, cancellationToken);
        
        _logger.LogInformation("GetCurrentWeather process finished...");
        
        return responseFromApi;
    }
}