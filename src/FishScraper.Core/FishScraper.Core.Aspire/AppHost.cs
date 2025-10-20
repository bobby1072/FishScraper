using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var useMockWeatherStackApi = builder.Configuration.GetValue<bool>("UseMockWeatherStackApi");


var fishScraperApi = builder
    .AddProject<Projects.FishScraper_Core_Api>("FishScraper-Api")
    .WithExternalHttpEndpoints();

if (useMockWeatherStackApi)
{
    builder.AddProject<Projects.FishScraper_Core_WeatherStack_Mock_Api>("WeatherStack-Mock")
        .WithExternalHttpEndpoints();

    fishScraperApi
        .WithEnvironment("WeatherStackConfig__BaseUrl", "https://localhost:6001");
}



await builder.Build().RunAsync();