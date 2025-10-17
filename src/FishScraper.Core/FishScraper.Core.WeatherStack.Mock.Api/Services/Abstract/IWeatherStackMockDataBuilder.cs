using FishScraper.Core.Schemas.WeatherStack.Request;
using FishScraper.Core.Schemas.WeatherStack.Response;

namespace FishScraper.Core.WeatherStack.Mock.Api.Services.Abstract;

internal interface IWeatherStackMockDataBuilder
{
    WeatherStackCurrentResponse CreateMockCurrentWeatherResponse(decimal latitude = 40.7128m, decimal longitude = -74.0060m, WeatherStackUnitsEnum units = WeatherStackUnitsEnum.Metric);
    WeatherStackFutureResponse CreateMockFutureWeatherResponse(decimal latitude = 40.7128m, decimal longitude = -74.0060m, WeatherStackUnitsEnum units = WeatherStackUnitsEnum.Metric, int forecastDays = 7);
}