using System;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using MudBlazor.Services;


namespace MusicLibrary.Web.Extensions;

/// <summary>
/// Extension methods for configuring the WebApplicationBuilder for MusicLibrary.
/// </summary>
public static class BuilderExtensions
{
    /// <summary>
    /// Configures all services and settings for the MusicLibrary Web application.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder instance.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMudServices();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();


        builder.Services.AddOutputCache();

        builder.Services.AddHttpClient<WeatherApiClient>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new("https+http://apiservice");
        });


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
