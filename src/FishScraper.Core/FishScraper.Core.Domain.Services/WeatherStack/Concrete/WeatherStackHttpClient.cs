using BT.Common.Api.Helpers.Exceptions;
using BT.Common.Http.Extensions;
using FishScraper.Core.Common.Configuration;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
using FishScraper.Core.Domain.Services.WeatherStack.Extensions;
using FishScraper.Core.Schemas.WeatherStack;
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
    public async Task<WeatherStackResponse> GetCurrentWeatherAsync(decimal latitude, decimal longitude, CancellationToken ct = default)
    {
        var response = await _weatherStackConfig.BaseUrl
            .AppendPathSegment("current")
            .AppendQueryParameter("access_key", _weatherStackConfig.ApiKey)
            .AppendQueryParameter("query", $"{latitude},{longitude}")
            .GetWeatherStackJsonAsync<WeatherStackResponse>(_client, _logger, ct);
        
        return response ?? throw new ApiServerException("Failed to get current weather stack");
    }
}