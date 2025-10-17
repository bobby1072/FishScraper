using System.Net.Http.Json;
using System.Text.Json;
using BT.Common.Api.Helpers.Exceptions;
using BT.Common.Http.Models;
using FishScraper.Core.Schemas.WeatherStack.Response;
using Microsoft.Extensions.Logging;

namespace FishScraper.Core.Domain.Services.WeatherStack.Extensions;

internal static class WeatherStackHttpRequestBuilderExtensions
{
    private static readonly JsonSerializerOptions _weatherStackJsonSerializerOptions = new (){ PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
    
    public static async Task<T?> GetWeatherStackJsonAsync<T>(this HttpRequestBuilder httpRequestBuilder, HttpClient client, ILogger? logger = null, CancellationToken token = default)
    {
        try
        {
            httpRequestBuilder.HttpMethod = HttpMethod.Get;
            
            using var httpReqMessage = httpRequestBuilder.ToHttpRequestMessage();
            using var httpResponse = await client.SendAsync(httpReqMessage, token);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var errorResponse = await httpResponse.Content.ReadFromJsonAsync<WeatherStackErrorResponse>(_weatherStackJsonSerializerOptions, token);
                
                logger?.LogDebug("GetWeatherStackJsonAsync returned error response: {@WeatherStackErrorResponse}", errorResponse);

                throw new ApiServerException(errorResponse?.Error.Info ?? "Weather stack error") { ExtraData = new Dictionary<string, object?> { {"ErrorResponse", errorResponse } }};
            }

            return await httpResponse.Content.ReadFromJsonAsync<T>(_weatherStackJsonSerializerOptions, token);
        }
        catch (Exception ex)
        {
            logger?.LogError(ex, "Exception occured while getting weather stack json");

            throw new ApiServerException(ex.Message, ex);
        }
    }
}