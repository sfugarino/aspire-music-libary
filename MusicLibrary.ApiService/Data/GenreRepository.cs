using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Repository for managing Genre entities in MongoDB.
/// </summary>
public class GenreRepository : MongoRepository<Genre>, IGenreRepository
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GenreRepository"/> class.
	/// </summary>
	/// <param name="database">The MongoDB database instance.</param>
	/// <param name="logger">The logger instance for MongoRepository.</param>
	public GenreRepository(IMongoDatabase database, ILogger<GenreRepository> logger)
		: base(database, "genres", logger)
	{
	}
}