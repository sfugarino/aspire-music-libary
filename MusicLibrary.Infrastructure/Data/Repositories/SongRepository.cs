using MusicLibrary.Domain.Interfaces.Data.DbContexts;
using MusicLibrary.Domain.Interfaces.Data.Repositories;
using Microsoft.Extensions.Logging;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Data.Repositories;

/// <summary>
/// Repository for managing Song entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SongRepository"/> class.
/// </remarks>
/// <param name="context">The music library context.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>   
public class SongRepository(IMusicLibraryContext context, ILogger<SongRepository> logger) 
    : MongoRepository<Song>(context.Songs, logger), ISongRepository
{
}