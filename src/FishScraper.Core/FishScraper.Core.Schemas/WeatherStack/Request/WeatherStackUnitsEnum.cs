using System.ComponentModel.DataAnnotations;

namespace FishScraper.Core.Schemas.WeatherStack.Request;

public enum WeatherStackUnitsEnum
{
    [Display(Name = "m")]
    Metric,
    [Display(Name = "s")]
    Scientific,
    [Display(Name = "f")]
    Fahrenheit
}