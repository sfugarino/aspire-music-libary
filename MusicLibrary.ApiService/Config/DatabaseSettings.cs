namespace MusicLibrary.ApiService.Config
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string GenreCollectionName { get; set; } = null!;
        public string ArtistCollectionName { get; set; } = null!;
        public string AlbumCollectionName { get; set; } = null!;

        public string SongCollectionName { get; set; } = null!;
    }
}