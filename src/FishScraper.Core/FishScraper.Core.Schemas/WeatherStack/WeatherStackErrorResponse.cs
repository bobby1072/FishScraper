namespace FishScraper.Core.Schemas.WeatherStack;

public sealed record WeatherStackErrorResponse
{
    public bool Success { get; init; }
    public required WeatherStackInnerErrorResponse Error { get; init; }
}
