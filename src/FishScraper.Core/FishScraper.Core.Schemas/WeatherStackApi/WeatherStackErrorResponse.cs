namespace FishScraper.Core.Schemas.WeatherStackApi;

public sealed record WeatherStackErrorResponse
{
    public bool Success { get; init; }
    public required WeatherStackInnerErrorResponse Error { get; init; }
}
