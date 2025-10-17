namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackAstroResponse
{
    public required string Sunrise { get; init; }
    public required string Sunset { get; init; }
    public required string Moonrise { get; init; }
    public required string Moonset { get; init; }
    public required string MoonPhase { get; init; }
    public int MoonIllumination { get; init; }
}
