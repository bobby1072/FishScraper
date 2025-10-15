using System.Text.Json;
using BT.Common.Api.Helpers.Extensions;
using BT.Common.Helpers;

var localLogger = LoggingHelper.CreateLogger();

try
{
    localLogger.LogInformation("Application is starting...");
    
    var builder = WebApplication.CreateBuilder(args);
    builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

    builder.Services.AddJsonLogging();

    builder
        .Services.AddControllers()
        .AddJsonOptions(opts => { opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; });
    
    builder.Services.AddResponseCompression();
    builder.Services.AddHealthChecks();
    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseRouting();

    app.UseResponseCompression();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app
        .UseCorrelationIdMiddleware();

    app.MapControllers();

    app
        .UseHealthGetEndpoints();

    await app.RunAsync();
}
catch (Exception ex)
{
    localLogger.LogCritical(ex, "Unhandled exception during application startup...");
}
finally
{
    localLogger.LogInformation("Application is exiting...");
}
