namespace FishScraper.Core.Common.Helpers;

public static class WeatherHelper
{
    public static bool IsValidLatitude(decimal latitude)
    {
        return latitude >= -90 && latitude <= 90;
    }

    public static bool IsValidLongitude(decimal longitude)
    {
        return longitude >= -180 && longitude <= 180;
    }
}