using FishScraper.Core.Common.Configuration;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
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
    public Task GetCurrentWeatherAsync(decimal latitude, decimal longitude, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}