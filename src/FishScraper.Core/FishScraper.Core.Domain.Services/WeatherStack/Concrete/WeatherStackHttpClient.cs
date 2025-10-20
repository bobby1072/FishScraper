using BT.Common.Api.Helpers.Exceptions;
using BT.Common.Helpers.Extensions;
using BT.Common.Http.Extensions;
using FishScraper.Core.Common.Configuration;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
using FishScraper.Core.Domain.Services.WeatherStack.Extensions;
using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;
using Microsoft.Extensions.Logging;

namespace FishScraper.Core.Domain.Services.WeatherStack.Concrete;

internal sealed class WeatherStackHttpClient: IWeatherStackHttpClient
{
    private readonly WeatherStackConfig _weatherStackConfig;
    private readonly HttpClient _client;
    private readonly ILogger<WeatherStackHttpClient> _logger;
    public WeatherStackHttpClient(HttpClient client, 
        WeatherStackConfig weatherStackConfig,
        ILogger<WeatherStackHttpClient> logger)
    {
        _client = client;
        _weatherStackConfig = weatherStackConfig;
        _logger = logger;
    }

    public async Task<WeatherStackFutureResponse> GetFutureWeatherAsync(decimal latitude, decimal longitude, int forecastDays,
        WeatherStackUnitsEnum units, CancellationToken ct = default)
    {
        var response = await _weatherStackConfig.BaseUrl
            .AppendPathSegment("future")
            .AppendQueryParameter("access_key", _weatherStackConfig.ApiKey)
            .AppendQueryParameter("query", $"{latitude},{longitude}")
            .AppendQueryParameter("units", units.GetDisplayName())
            .AppendQueryParameter("forecast_days", forecastDays.ToString())
            .GetWeatherStackJsonAsync<WeatherStackFutureResponse>(_client, _logger, ct);
        
        return response ?? throw new ApiServerException("Failed to get current weather stack");
    }
    public async Task<WeatherStackCurrentResponse> GetCurrentWeatherAsync(decimal latitude, decimal longitude, WeatherStackUnitsEnum units, CancellationToken ct = default)
    {
        var response = await _weatherStackConfig.BaseUrl
            .AppendPathSegment("current")
            .AppendQueryParameter("access_key", _weatherStackConfig.ApiKey)
            .AppendQueryParameter("query", $"{latitude},{longitude}")
            .AppendQueryParameter("units", units.GetDisplayName())
            .GetWeatherStackJsonAsync<WeatherStackCurrentResponse>(_client, _logger, ct);
        
        return response ?? throw new ApiServerException("Failed to get current weather stack");
    }
}