using Microsoft.Extensions.Logging;
using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing Album entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AlbumRepository"/> class.
/// </remarks>
/// <param name="context">The music library context.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class AlbumRepository(IMusicLibraryContext context, ILogger<AlbumRepository> logger) 
    : MongoRepository<Album>(context.Albums, logger), IAlbumRepository
{
}