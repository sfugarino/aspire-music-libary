using MongoDB.Driver;
using MusicLibrary.ApiService.Config;
using MusicLibrary.ApiService.Interfaces;
using MusicLibrary.ApiService.Schemas;

namespace MusicLibrary.ApiService.Data;

/// <summary>
/// Repository for managing Artist entities in MongoDB.
/// </summary>
public class ArtistRepository : MongoRepository<Artist>, IArtistRepository
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ArtistRepository"/> class.
	/// </summary>
	/// <param name="database">The MongoDB database instance.</param>
	/// <param name="logger">The logger instance for MongoRepository.</param>
	public ArtistRepository(IMongoDatabase database, ILogger<ArtistRepository> logger)
		: base(database, "artists", logger)
	{
	}
}