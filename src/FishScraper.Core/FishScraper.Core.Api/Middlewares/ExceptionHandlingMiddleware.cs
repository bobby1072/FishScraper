using System.Net;
using System.Net.Mime;
using BT.Common.Api.Helpers.Exceptions;
using BT.Common.Api.Helpers.Models;
using FishScraper.Core.Common;

namespace FishScraper.Core.Api.Middlewares;

internal sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (ApiServerException ex)
        {
            _logger.Log(ex.LogLevel, ex, "FishScraper API server exception occurred during request processing");
            await SendExceptionResponse(httpContext, ex.StatusCode, FishScraperConstants.ExceptionConstants.InternalServerError);
        }
        catch (ApiClientException ex)
        {
            _logger.Log(ex.LogLevel ,ex, "FishScraper client API exception occurred during request processing");
            await SendExceptionResponse(httpContext, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred during request processing");
            await SendExceptionResponse(httpContext, HttpStatusCode.InternalServerError, FishScraperConstants.ExceptionConstants.InternalServerError);
        }
    }

    private static async Task SendExceptionResponse(HttpContext httpContext, HttpStatusCode statusCode, string message)
    {
        httpContext.Response.Clear();
        
        httpContext.Response.StatusCode = (int)statusCode;
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;
        
        await httpContext.Response.WriteAsJsonAsync(new WebOutcome {ExceptionMessage = message});
    }
}