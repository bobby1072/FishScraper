namespace FishScraper.Core.Schemas.WeatherStack.Response;

public sealed record WeatherStackHourlyForecast
{
    public required string Time { get; init; }
    public int Temperature { get; init; }
    public int WindSpeed { get; init; }
    public int WindDegree { get; init; }
    public required string WindDir { get; init; }
    public int WeatherCode { get; init; }
    public string[] WeatherIcons { get; init; } = [];
    public string[] WeatherDescriptions { get; init; } = [];
    public int Precip { get; init; }
    public int Humidity { get; init; }
    public int Visibility { get; init; }
    public int Pressure { get; init; }
    public int Cloudcover { get; init; }
    public int Heatindex { get; init; }
    public int Dewpoint { get; init; }
    public int Windchill { get; init; }
    public int Windgust { get; init; }
    public int Feelslike { get; init; }
    public int Chanceofrain { get; init; }
    public int Chanceofremdry { get; init; }
    public int Chanceofwindy { get; init; }
    public int Chanceofovercast { get; init; }
    public int Chanceofsunshine { get; init; }
    public int Chanceoffrost { get; init; }
    public int Chanceofhightemp { get; init; }
    public int Chanceoffog { get; init; }
    public int Chanceofsnow { get; init; }
    public int Chanceofthunder { get; init; }
    public int UvIndex { get; init; }
    public required WeatherStackAirQualityResponse AirQuality { get; init; }
}