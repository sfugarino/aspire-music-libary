using FastEndpoints;
using FastEndpoints.Swagger;
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
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;


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
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
             // Add ProblemDetails and exception handler
        builder.Services.AddProblemDetails(config =>
        {
            config.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);

            };
        });

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


        builder.Services.RegisterQueryHandlers();

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
        builder.Services.AddFastEndpoints()
                        .AddOpenApi(options =>
                        {
                           options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
                        });

        builder.Services.AddHttpClient();

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

    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var keycloakSettings = builder.Configuration.GetSection("Keycloak").Get<KeycloakSettings>()
            ?? throw new InvalidOperationException("Keycloak settings are not configured properly.");

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = keycloakSettings.BaseUrl,

                ValidateAudience = true,
                ValidAudience = "account",

                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,

                IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
                {
                    var client = new HttpClient();
                    var keyUri = $"{parameters.ValidIssuer}/protocol/openid-connect/certs";
                    var response = client.Send(new HttpRequestMessage(HttpMethod.Get, keyUri));

                    using (Stream responseStream = response.Content.ReadAsStream())
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var json =  streamReader.ReadToEnd();
                        var keys = new JsonWebKeySet(json);
                        return keys.GetSigningKeys();
                    }  
                }
            };

            options.RequireHttpsMetadata = false; // Only for develop
            options.SaveToken = true;
        });

        builder.Services.AddAuthorization();

        return builder;
    }

    private static async Task<IList<SecurityKey>> GetKeycloakSigningKeysAsync(string issuer)
    {
        using var httpClient = new HttpClient();
        var keyUri = $"{issuer}/protocol/openid-connect/auth";
        var response = await httpClient.GetAsync(keyUri);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var keys = new JsonWebKeySet(json);
        return keys.GetSigningKeys();
    }
}



