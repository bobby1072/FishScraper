namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackLocation
{
    public string? Name { get; init; }
    public string? Country { get; init; }
    public string? Region { get; init; }
    public string? Lat { get; init; }
    public string? Lon { get; init; }
    public string? TimezoneId { get; init; }
    public string? Localtime { get; init; }
    public int LocaltimeEpoch { get; init; }
    public string? UtcOffset { get; init; }
}
