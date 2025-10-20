namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackRequestResponse
{
    public required string Type { get; init; }
    public required string Query { get; init; }
    public required string Language { get; init; }
    public required string Unit { get; init; }
}
