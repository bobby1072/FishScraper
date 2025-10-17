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

    public async Task<WeatherStackResponse> GetCurrentWeatherAsync(GetCurrentWeatherInputParams input, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Starting GetCurrentWeather process...");

        if (!WeatherHelper.IsValidLatitude(input.Latitude) || !WeatherHelper.IsValidLongitude(input.Longitude))
        {
            throw new ApiClientException(HttpStatusCode.BadRequest, "Invalid Latitude or Longitude");
        }
        
        var responseFromApi = await _weatherHttpClient.GetCurrentWeatherAsync(input.Latitude, input.Longitude);
        
        _logger.LogInformation("GetCurrentWeather process finished...");
        
        return responseFromApi;
    }
}