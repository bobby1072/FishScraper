using BT.Common.Helpers;
using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.WeatherStack.Mock.Api.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FishScraper.Core.WeatherStack.Mock.Api.Controllers;

[ApiController]
public sealed class WeatherStackController: ControllerBase
{
    private readonly IWeatherStackMockDataBuilder _mockDataBuilder;

    public WeatherStackController(IWeatherStackMockDataBuilder mockDataBuilder)
    {
        _mockDataBuilder = mockDataBuilder;
    }
    [HttpGet("current")]
    public Task<IActionResult> GetCurrentWeather(string access_key, string query, string units = "m")
    {
        try
        {
            var latLng = GetLatLngFromQuery(query);
            var futureResult = _mockDataBuilder.CreateMockCurrentWeatherResponse(latLng.Lat,
                latLng.Lng,
                EnumHelper.Parse<WeatherStackUnitsEnum>(units));

            return Task.FromResult((IActionResult)Ok(futureResult));
        }
        catch
        {
            var errorResponse = _mockDataBuilder.CreateErrorResponse();
            return Task.FromResult((IActionResult)BadRequest(errorResponse));
        }
    }
    [HttpGet("future")]
    public Task<IActionResult> GetFutureWeather(string access_key, string query,
        int forecast_days = 7, string units = "m")
    {
        try
        {
            var latLng = GetLatLngFromQuery(query);
            var futureResult = _mockDataBuilder.CreateMockFutureWeatherResponse(latLng.Lat,
                latLng.Lng,
                EnumHelper.Parse<WeatherStackUnitsEnum>(units),
                forecast_days);

            return Task.FromResult((IActionResult)Ok(futureResult));
        }
        catch
        {
            var errorResponse = _mockDataBuilder.CreateErrorResponse();
            return Task.FromResult((IActionResult)BadRequest(errorResponse));
        }
    }

    private static (decimal Lat, decimal Lng) GetLatLngFromQuery(string query)
    {
        var splitQuery = query.Split(',');
        return (decimal.Parse(splitQuery[0]), decimal.Parse(splitQuery[1]));
    }
}