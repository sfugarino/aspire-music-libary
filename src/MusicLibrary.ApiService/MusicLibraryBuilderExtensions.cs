using FastEndpoints;
using MusicLibrary.Infrastructure.Data.Repositories;
using MusicLibrary.ApiService.Exceptions;
using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Infrastructure.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Domain.Config;
using MusicLibrary.Application.Abstractions.Messaging;
using MusicLibrary.Application.Queries.Artists;


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

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllArtistsQuery>());

        return builder;
    }
}
