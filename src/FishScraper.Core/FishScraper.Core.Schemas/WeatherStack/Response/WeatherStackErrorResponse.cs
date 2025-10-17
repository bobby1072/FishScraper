namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackErrorResponse
{
    public bool Success { get; init; }
    public required WeatherStackInnerErrorResponse Error { get; init; }
}
