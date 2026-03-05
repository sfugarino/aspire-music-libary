using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Repository for managing Song entities in MongoDB.
/// </summary>
public class SongRepository : MongoRepository<Song>, ISongRepository
{
	/// <summary>
	/// Initializes a new instance of the <see cref="SongRepository"/> class.
	/// </summary>
	/// <param name="database">The MongoDB database instance.</param>
	/// <param name="logger">The logger instance for MongoRepository.</param>
	public SongRepository(IMongoDatabase database, ILogger<SongRepository> logger)
		: base(database, "songs", logger)
	{
	}
}