namespace FishScraper.Core.Schemas.WeatherStackApi;

public sealed record WeatherStackInnerErrorResponse
{
    public int Code { get; init; }
    public required string Type { get; init; }
    public required string Info { get; init; }
}
