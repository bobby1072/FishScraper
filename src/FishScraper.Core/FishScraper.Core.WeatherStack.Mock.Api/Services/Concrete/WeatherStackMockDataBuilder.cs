using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;
using FishScraper.Core.WeatherStack.Mock.Api.Services.Abstract;

namespace FishScraper.Core.WeatherStack.Mock.Api.Services.Concrete;

internal sealed class WeatherStackMockDataBuilder : IWeatherStackMockDataBuilder
{
    private static readonly Random _random = new();
    
    private static readonly string[] _cities = 
    {
        "New York", "London", "Paris", "Tokyo", "Sydney", "Berlin", "Madrid", "Rome", "Amsterdam", "Toronto"
    };
    
    private static readonly string[] _countries = 
    {
        "United States", "United Kingdom", "France", "Japan", "Australia", "Germany", "Spain", "Italy", "Netherlands", "Canada"
    };
    
    private static readonly string[] _regions = 
    {
        "New York", "England", "Ile-de-France", "Tokyo", "New South Wales", "Berlin", "Madrid", "Lazio", "North Holland", "Ontario"
    };
    
    private static readonly string[] _weatherDescriptions = 
    {
        "Sunny", "Partly Cloudy", "Cloudy", "Overcast", "Light Rain", "Rain", "Heavy Rain", "Snow", "Fog", "Clear"
    };
    
    private static readonly string[] _weatherIcons = 
    {
        "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0001_sunny.png",
        "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0002_sunny_intervals.png",
        "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0003_white_cloud.png",
        "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0004_black_low_cloud.png",
        "https://assets.weatherstack.com/images/wsymbols01_png_64/wsymbol_0009_light_rain.png"
    };
    
    private static readonly string[] _windDirections = 
    {
        "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW"
    };
    
    private static readonly string[] _moonPhases = 
    {
        "New Moon", "Waxing Crescent", "First Quarter", "Waxing Gibbous", "Full Moon", "Waning Gibbous", "Last Quarter", "Waning Crescent"
    };

    public WeatherStackErrorResponse CreateErrorResponse()
    {
        return new WeatherStackErrorResponse
        {
            Error = new WeatherStackInnerErrorResponse
            {
                Info = "It failed",
                Type = "Error",
                Code = 500
            },
            Success = false
        };
    }
    public WeatherStackCurrentResponse CreateMockCurrentWeatherResponse(decimal latitude = 40.7128m, decimal longitude = -74.0060m, WeatherStackUnitsEnum units = WeatherStackUnitsEnum.Metric)
    {
        var cityIndex = _random.Next(_cities.Length);
        var now = DateTime.UtcNow;
        
        return new WeatherStackCurrentResponse
        {
            Request = CreateMockRequestResponse(latitude, longitude, units),
            Location = CreateMockLocationResponse(cityIndex, now),
            Current = CreateMockCurrentData()
        };
    }
    
    public WeatherStackFutureResponse CreateMockFutureWeatherResponse(decimal latitude = 40.7128m, decimal longitude = -74.0060m, WeatherStackUnitsEnum units = WeatherStackUnitsEnum.Metric, int forecastDays = 7)
    {
        var cityIndex = _random.Next(_cities.Length);
        var now = DateTime.UtcNow;
        
        return new WeatherStackFutureResponse
        {
            Request = CreateMockRequestResponse(latitude, longitude, units),
            Location = CreateMockLocationResponse(cityIndex, now),
            Current = CreateMockCurrentData(),
            Forecast = CreateMockForecast(forecastDays)
        };
    }
    
    private static WeatherStackRequestResponse CreateMockRequestResponse(decimal latitude, decimal longitude, WeatherStackUnitsEnum units)
    {
        return new WeatherStackRequestResponse
        {
            Type = "LatLon",
            Query = $"{latitude},{longitude}",
            Language = "en",
            Unit = units.ToString().ToLower()
        };
    }
    
    private static WeatherStackLocationResponse CreateMockLocationResponse(int cityIndex, DateTime now)
    {
        return new WeatherStackLocationResponse
        {
            Name = _cities[cityIndex],
            Country = _countries[cityIndex],
            Region = _regions[cityIndex],
            Lat = (_random.NextDouble() * 180 - 90).ToString("F3"),
            Lon = (_random.NextDouble() * 360 - 180).ToString("F3"),
            TimezoneId = "UTC",
            Localtime = now.ToString("yyyy-MM-dd HH:mm"),
            LocaltimeEpoch = (int)((DateTimeOffset)now).ToUnixTimeSeconds(),
            UtcOffset = "0.0"
        };
    }
    
    private static WeatherStackCurrentData CreateMockCurrentData()
    {
        return new WeatherStackCurrentData
        {
            ObservationTime = DateTime.UtcNow.ToString("hh:mm tt"),
            Temperature = _random.Next(-10, 40),
            WeatherCode = _random.Next(100, 400),
            WeatherIcons = [_weatherIcons[_random.Next(_weatherIcons.Length)]],
            WeatherDescriptions = [_weatherDescriptions[_random.Next(_weatherDescriptions.Length)]],
            AirQuality = CreateMockAirQuality(),
            WindSpeed = _random.Next(0, 50),
            WindDegree = _random.Next(0, 360),
            WindDir = _windDirections[_random.Next(_windDirections.Length)],
            Pressure = _random.Next(980, 1040),
            Precip = _random.Next(0, 20),
            Humidity = _random.Next(20, 100),
            Cloudcover = _random.Next(0, 100),
            Feelslike = _random.Next(-15, 45),
            UvIndex = _random.Next(0, 11),
            Visibility = _random.Next(1, 20)
        };
    }
    
    private static WeatherStackAirQualityResponse CreateMockAirQuality()
    {
        return new WeatherStackAirQualityResponse
        {
            Co = (_random.NextDouble() * 1000).ToString("F2"),
            No2 = (_random.NextDouble() * 100).ToString("F3"),
            O3 = (_random.NextDouble() * 200).ToString("F0"),
            So2 = (_random.NextDouble() * 50).ToString("F2"),
            Pm25 = (_random.NextDouble() * 50).ToString("F2"),
            Pm10 = (_random.NextDouble() * 100).ToString("F2"),
            UsEpaIndex = _random.Next(1, 7).ToString(),
            GbDefraIndex = _random.Next(1, 11).ToString()
        };
    }
    
    private static WeatherStackAstroResponse CreateMockAstro()
    {
        return new WeatherStackAstroResponse
        {
            Sunrise = $"{_random.Next(5, 8):D2}:{_random.Next(0, 60):D2} AM",
            Sunset = $"{_random.Next(5, 8):D2}:{_random.Next(0, 60):D2} PM",
            Moonrise = $"{_random.Next(1, 12):D2}:{_random.Next(0, 60):D2} {(_random.Next(2) == 0 ? "AM" : "PM")}",
            Moonset = $"{_random.Next(1, 12):D2}:{_random.Next(0, 60):D2} {(_random.Next(2) == 0 ? "AM" : "PM")}",
            MoonPhase = _moonPhases[_random.Next(_moonPhases.Length)],
            MoonIllumination = _random.Next(0, 101)
        };
    }
    
    private static WeatherStackForecast CreateMockForecast(int days)
    {
        var forecast = new WeatherStackForecast();
        var startDate = DateTime.UtcNow.Date;
        
        for (int i = 0; i < days; i++)
        {
            var date = startDate.AddDays(i);
            var dateKey = date.ToString("yyyy-MM-dd");
            
            forecast.DailyForecasts[dateKey] = new WeatherStackDailyForecast
            {
                Date = dateKey,
                DateEpoch = (int)((DateTimeOffset)date).ToUnixTimeSeconds(),
                Astro = CreateMockAstro(),
                Mintemp = _random.Next(-5, 20),
                Maxtemp = _random.Next(20, 40),
                Avgtemp = _random.Next(10, 30),
                Totalsnow = _random.Next(0, 10),
                Sunhour = Math.Round(_random.NextDouble() * 12, 1),
                UvIndex = _random.Next(0, 11),
                AirQuality = CreateMockAirQuality(),
                Hourly = CreateMockHourlyForecasts()
            };
        }
        
        return forecast;
    }
    
    private static WeatherStackHourlyForecast[] CreateMockHourlyForecasts()
    {
        var hourlyForecasts = new List<WeatherStackHourlyForecast>();
        
        // Create forecasts for every 3 hours (8 forecasts per day)
        for (int hour = 0; hour < 24; hour += 3)
        {
            hourlyForecasts.Add(new WeatherStackHourlyForecast
            {
                Time = (hour * 100).ToString(), // 0, 300, 600, 900, etc.
                Temperature = _random.Next(-10, 40),
                WindSpeed = _random.Next(0, 50),
                WindDegree = _random.Next(0, 360),
                WindDir = _windDirections[_random.Next(_windDirections.Length)],
                WeatherCode = _random.Next(100, 400),
                WeatherIcons = [_weatherIcons[_random.Next(_weatherIcons.Length)]],
                WeatherDescriptions = [_weatherDescriptions[_random.Next(_weatherDescriptions.Length)]],
                Precip = _random.Next(0, 20),
                Humidity = _random.Next(20, 100),
                Visibility = _random.Next(1, 20),
                Pressure = _random.Next(980, 1040),
                Cloudcover = _random.Next(0, 100),
                Heatindex = _random.Next(-15, 45),
                Dewpoint = _random.Next(-20, 25),
                Windchill = _random.Next(-25, 20),
                Windgust = _random.Next(0, 70),
                Feelslike = _random.Next(-20, 45),
                Chanceofrain = _random.Next(0, 101),
                Chanceofremdry = _random.Next(0, 101),
                Chanceofwindy = _random.Next(0, 101),
                Chanceofovercast = _random.Next(0, 101),
                Chanceofsunshine = _random.Next(0, 101),
                Chanceoffrost = _random.Next(0, 101),
                Chanceofhightemp = _random.Next(0, 101),
                Chanceoffog = _random.Next(0, 101),
                Chanceofsnow = _random.Next(0, 101),
                Chanceofthunder = _random.Next(0, 101),
                UvIndex = _random.Next(0, 11),
                AirQuality = CreateMockAirQuality()
            });
        }
        
        return hourlyForecasts.ToArray();
    }
}