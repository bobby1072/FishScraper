using BT.Common.Helpers;
using BT.Common.Http.Extensions;
using FishScraper.Core.Common.Configuration;
using FishScraper.Core.Domain.Services.WeatherStack.Abstract;
using FishScraper.Core.Domain.Services.WeatherStack.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FishScraper.Core.Domain.Services.Extensions;

public static class FishScraperDomainServiceCollectionExtensions
{
    public static IServiceCollection AddFishScraperApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var foundWeatherStackConfigSection = configuration.GetSection(nameof(WeatherStackConfig));

        if (!foundWeatherStackConfigSection.Exists())
        {
            throw new ApplicationException("Missing weather stack config...");
        }
        
        services
            .AddJsonLogging()
            .AddHttpClient();
        
        services
            .AddHttpClientWithResilience<IWeatherStackHttpClient, WeatherStackHttpClient>(
                foundWeatherStackConfigSection.Get<WeatherStackConfig>() ?? throw new ApplicationException("Missing weather stack config")
            );
        
        return services;
    }
}