using FastEndpoints;
using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Data;
using MusicLibrary.ApiService.Exceptions;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Extensions;

/// <summary>
/// Extension methods for configuring the WebApplicationBuilder for MusicLibrary.
/// </summary>
public static class MusicLibraryBuilderExtensions
{
    /// <summary>
    /// Configures all services and settings for the MusicLibrary API.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder instance.</param>
    /// <returns>The same builder instance for chaining.</returns>
    public static WebApplicationBuilder ConfigureMusicLibrary(this WebApplicationBuilder builder)
    {
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
        var mongoDbSection = builder.Configuration.GetSection("MusicLibraryDatabase")!;
        var mongoDbSettings = mongoDbSection.Get<DatabaseSettings>()!;
        builder.Services.Configure<DatabaseSettings>(mongoDbSection);
        var client = new MongoClient(mongoDbSettings.ConnectionString);
        var database = client.GetDatabase(mongoDbSettings.DatabaseName);
        builder.Services.AddSingleton<IMongoDatabase>(database);

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
}
