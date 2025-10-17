namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackAstro
{
    public string? Sunrise { get; init; }
    public string? Sunset { get; init; }
    public string? Moonrise { get; init; }
    public string? Moonset { get; init; }
    public string? MoonPhase { get; init; }
    public int MoonIllumination { get; init; }
}
