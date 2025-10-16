using BT.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace FishScraper.Core.Domain.Services.Extensions;

public static class FishScraperDomainServiceCollectionExtensions
{
    public static IServiceCollection AddFishScraperApplication(this IServiceCollection services)
    {
        services
            .AddJsonLogging()
            .AddHttpClient();
        
        
        return services;
    }
}