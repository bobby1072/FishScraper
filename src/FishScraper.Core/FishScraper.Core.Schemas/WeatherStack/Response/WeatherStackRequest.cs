namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackRequest
{
    public string? Type { get; init; }
    public string? Query { get; init; }
    public string? Language { get; init; }
    public string? Unit { get; init; }
}
