using FastEndpoints;
using MusicLibrary.Infrastructure.Data.Repositories;
using MusicLibrary.ApiService.Exceptions;
using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Infrastructure.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Domain.Config;
using MusicLibrary.Application;
using MusicLibrary.Application.Queries.Artists;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;


namespace MusicLibrary.ApiService.Extensions;

/// <summary>
/// Extension methods for configuring the WebApplicationBuilder for MusicLibrary.
/// </summary>
public static class BuilderExtensions
{
    /// <summary>
    /// Configures all services and settings for the MusicLibrary API.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder instance.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static WebApplicationBuilder ConfigureMusicLibrary(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplication();

        // Add ProblemDetails and exception handler
        builder.Services.AddProblemDetails(config =>
        {
            config.CustomizeProblemDetails = content =>
            {
                content.ProblemDetails.Extensions.TryAdd("requestId", content.HttpContext.TraceIdentifier);
            };
        });
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        // Add service defaults & Aspire client integrations
        builder.AddServiceDefaults();

        // MongoDB configuration  
        
        var settings = builder.Configuration.GetSection("MusicLibraryDatabase").Get<DatabaseSettings>()
            ?? throw new InvalidOperationException("Database settings are not configured properly.");

         // Add MusicLibraryContext
        builder.Services.AddSingleton<IMusicLibraryContext>(new MusicLibraryContext(settings));

        // Register repositories
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
        builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
        builder.Services.AddScoped<ISongRepository, SongRepository>();

        // OpenAPI and FastEndpoints
        builder.Services.AddOpenApi();
        builder.Services.AddFastEndpoints();

        return builder;
    }

    public static WebApplicationBuilder AddOpenTelemetry(this WebApplicationBuilder builder)
    {
        var tracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
        var otel = builder.Services.AddOpenTelemetry();

        // Configure OpenTelemetry Resources with the application name
        otel.ConfigureResource(resource => resource
            .AddService(serviceName: builder.Environment.ApplicationName));

        // Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
        otel.WithMetrics(metrics => metrics
            // Metrics provider from OpenTelemetry
            .AddAspNetCoreInstrumentation()
            // Metrics provides by ASP.NET Core in .NET 8
            .AddMeter("Microsoft.AspNetCore.Hosting")
            .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
            // Metrics provided by System.Net libraries
            .AddMeter("System.Net.Http")
            .AddMeter("System.Net.NameResolution")
            .AddPrometheusExporter());

   
        otel.WithTracing(tracing =>
        {
            tracing.AddAspNetCoreInstrumentation();
            tracing.AddHttpClientInstrumentation();
            if (tracingOtlpEndpoint != null)
            {
                tracing.AddOtlpExporter(otlpOptions =>
                {
                    otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
                });
            }
            else
            {
                tracing.AddConsoleExporter();
            }
        });
        

        return builder;
    }
}
