using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MusicLibrary.Domain.Config;
using MusicLibrary.Domain.Interfaces.Persistence;
using MusicLibrary.Domain.Schemas;

namespace MusicLibrary.Infrastructure.Persistence.Repositories;

/// <summary>
/// Repository for managing Genre entities in MongoDB.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GenreRepository"/> class.
/// </remarks>
/// <param name="database">The MongoDB database instance.</param>
/// <param name="logger">The logger instance for MongoRepository.</param>
public class GenreRepository(IMongoDatabase database, ILogger<GenreRepository> logger) 
    : MongoRepository<Genre>(database, "genres", logger), IGenreRepository
{
}