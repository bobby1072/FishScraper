namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackLocation
{
    public required string Name { get; init; }
    public required string Country { get; init; }
    public required string Region { get; init; }
    public required string Lat { get; init; }
    public required string Lon { get; init; }
    public required string TimezoneId { get; init; }
    public required string Localtime { get; init; }
    public int LocaltimeEpoch { get; init; }
    public required string UtcOffset { get; init; }
}
