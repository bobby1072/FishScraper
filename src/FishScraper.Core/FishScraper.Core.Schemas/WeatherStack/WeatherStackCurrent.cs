namespace FishScraper.Core.Schemas.WeatherStack;

public sealed record WeatherStackCurrent
{
    public required string ObservationTime { get; init; }
    public int Temperature { get; init; }
    public int WeatherCode { get; init; }
    public required string[] WeatherIcons { get; init; }
    public required string[] WeatherDescriptions { get; init; }
    public required WeatherStackAstro Astro { get; init; }
    public required WeatherStackAirQuality AirQuality { get; init; }
    public int WindSpeed { get; init; }
    public int WindDegree { get; init; }
    public required string WindDir { get; init; }
    public int Pressure { get; init; }
    public int Precip { get; init; }
    public int Humidity { get; init; }
    public int Cloudcover { get; init; }
    public int Feelslike { get; init; }
    public int UvIndex { get; init; }
    public int Visibility { get; init; }
}
