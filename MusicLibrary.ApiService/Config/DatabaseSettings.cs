namespace MusicLibrary.ApiService.Config
{
    /// <summary>
    /// Represents MongoDB database and collection settings for the music library.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Gets or sets the MongoDB connection string.
        /// </summary>
        public string ConnectionString { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the MongoDB database.
        /// </summary>
        public string DatabaseName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the genre collection.
        /// </summary>
        public string GenreCollectionName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the artist collection.
        /// </summary>
        public string ArtistCollectionName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the album collection.
        /// </summary>
        public string AlbumCollectionName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the song collection.
        /// </summary>
        public string SongCollectionName { get; set; } = null!;
    }
}