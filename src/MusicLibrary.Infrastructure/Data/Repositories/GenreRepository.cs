using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using Microsoft.Extensions.Logging;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing Genre entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GenreRepository"/> class.
/// </remarks>
/// <param name="context">The music library context.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class GenreRepository(IMusicLibraryContext context, ILogger<GenreRepository> logger) 
    : MongoRepository<Genre>(context.Genres, logger), IGenreRepository
{
}