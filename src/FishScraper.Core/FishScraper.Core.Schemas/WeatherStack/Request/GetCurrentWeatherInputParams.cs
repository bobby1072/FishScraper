namespace FishScraper.Core.Schemas.WeatherStack.Request;

public sealed record GetCurrentWeatherInputParams
{
    public required decimal Latitude { get; init; }
    public required decimal Longitude { get; init; }

    public bool Equals(GetCurrentWeatherInputParams? other)
    {
        return Latitude.Equals(other?.Latitude) && Longitude.Equals(other.Longitude);
    }
    
    public override int GetHashCode() => HashCode.Combine(Latitude, Longitude);
}