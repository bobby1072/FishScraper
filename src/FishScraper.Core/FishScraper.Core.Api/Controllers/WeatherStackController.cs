using BT.Common.Api.Helpers.Models;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;
using Microsoft.AspNetCore.Mvc;

namespace FishScraper.Core.Api.Controllers;

public sealed class WeatherStackController : BaseController
{
    private readonly IWeatherStackProcessingManager _weatherStackProcessingManager;

    public WeatherStackController(IWeatherStackProcessingManager weatherStackProcessingManager)
    {
        _weatherStackProcessingManager = weatherStackProcessingManager;
    }

    [HttpPost("CurrentWeather")]
    public async Task<ActionResult<WebOutcome<WeatherStackCurrentResponse>>> GetCurrentWeather(
        [FromBody] GetCurrentWeatherInputParams getCurrentWeatherInputParams,
        CancellationToken ct = default
    )
    {
        var result = await _weatherStackProcessingManager.GetCurrentWeatherAsync(
            getCurrentWeatherInputParams,
            ct
        );

        return new WebOutcome<WeatherStackCurrentResponse> { Data = result };
    }
}
