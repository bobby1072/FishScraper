using BT.Common.Polly.Models.Concrete;

namespace FishScraper.Core.Common.Configuration;

public record WeatherStackConfig : PollyRetrySettings
{
    public required string ApiKey { get; init; }
    public required string BaseUrl { get; init; }
}