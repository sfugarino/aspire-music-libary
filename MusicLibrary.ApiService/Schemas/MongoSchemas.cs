using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas
{
    /// <summary>
    /// Represents an artist in the music library.
    /// </summary>
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the unique identifier for the artist.
        /// </summary>
        public string? Id { get; set; }

        [BsonElement("name")]
        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        public required string Name { get; set; }

        [BsonElement("bio")]
        /// <summary>
        /// Gets or sets the biography of the artist.
        /// </summary>
        public string? Bio { get; set; }

        [BsonElement("origin")]
        /// <summary>
        /// Gets or sets the origin of the artist.
        /// </summary>
        public string? Origin { get; set; }

        [BsonElement("image")]
        /// <summary>
        /// Gets or sets the image URL of the artist.
        /// </summary>
        public string? Image { get; set; }

        [BsonElement("birthDate")]
        /// <summary>
        /// Gets or sets the birth date of the artist.
        /// </summary>
        public DateOnly? BirthDay { get; set; }

        [BsonElement("genreIds")]
        /// <summary>
        /// Gets or sets the list of genre IDs associated with the artist.
        /// </summary>
        public List<ObjectId> GenreIds { get; set; } = [];

        [BsonElement("createdAt")]
        /// <summary>
        /// Gets or sets the creation date of the artist record.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        /// <summary>
        /// Gets or sets the last update date of the artist record.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        /// <summary>
        /// Gets or sets a value indicating whether the artist is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Represents an album in the music library.
    /// </summary>
    public class Album
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the unique identifier for the album.
        /// </summary>
        public string? Id { get; set; }

        [BsonElement("title")]
        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        public required string Title { get; set; }

        [BsonElement("artistId")]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the artist ID for the album (references Artist).
        /// </summary>
        public required string? ArtistId { get; set; } // references Artist
        
        [BsonElement("artistName")]
        /// <summary>
        /// Gets or sets the artist name (denormalized for easy access).
        /// </summary>
        public string? ArtistName { get; set; } // denormalized for easy access

        [BsonElement("releaseYear")]
        /// <summary>
        /// Gets or sets the release year of the album.
        /// </summary>
        public int? ReleaseYear { get; set; }

        [BsonElement("genreIds")]
        /// <summary>
        /// Gets or sets the list of genre IDs associated with the album (references Genre).
        /// </summary>
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("coverImage")]
        /// <summary>
        /// Gets or sets the cover image URL of the album.
        /// </summary>
        public string? CoverImage { get; set; }

        [BsonElement("recordLabel")]
        /// <summary>
        /// Gets or sets the record label of the album.
        /// </summary>
        public string? RecordLabel { get; set; }

        [BsonElement("createdAt")]
        /// <summary>
        /// Gets or sets the creation date of the album record.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        /// <summary>
        /// Gets or sets the last update date of the album record.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        /// <summary>
        /// Gets or sets a value indicating whether the album is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Represents a song in the music library.
    /// </summary>
    public class Song
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the unique identifier for the song.
        /// </summary>
        public string? Id { get; set; }

        [BsonElement("title")]
        /// <summary>
        /// Gets or sets the title of the song.
        /// </summary>
        public required string Title { get; set; }

        [BsonElement("albumId")]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the album ID for the song (references Album).
        /// </summary>
        public required string? AlbumId { get; set; } // references Album

        [BsonElement("artistId")]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the artist ID for the song (references Artist).
        /// </summary>
        public required string? ArtistId { get; set; } // references Artist
        
        [BsonElement("artistName")]
        /// <summary>
        /// Gets or sets the artist name (denormalized for easy access).
        /// </summary>
        public string? ArtistName { get; set; } // denormalized for easy access

        [BsonElement("duration")]
        /// <summary>
        /// Gets or sets the duration of the song in seconds.
        /// </summary>
        public int? Duration { get; set; } // seconds

        [BsonElement("genreIds")]
        /// <summary>
        /// Gets or sets the list of genre IDs associated with the song (references Genre).
        /// </summary>
        public List<ObjectId> GenreIds { get; set; } = []; // references Genre

        [BsonElement("trackNumber")]
        /// <summary>
        /// Gets or sets the track number of the song in the album.
        /// </summary>
        public int? TrackNumber { get; set; }

        [BsonElement("audioFile")]
        /// <summary>
        /// Gets or sets the audio file URL of the song.
        /// </summary>
        public string? AudioFile { get; set; }
        
        [BsonElement("lyrics")]
        /// <summary>
        /// Gets or sets the lyrics of the song.
        /// </summary>
        public string? Lyrics { get; set; }

        [BsonElement("createdAt")]
        /// <summary>
        /// Gets or sets the creation date of the song record.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        /// <summary>
        /// Gets or sets the last update date of the song record.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        /// <summary>
        /// Gets or sets a value indicating whether the song is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }

    /// <summary>
    /// Represents a genre in the music library.
    /// </summary>
    public class Genre
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// Gets or sets the unique identifier for the genre.
        /// </summary>
        public string? Id { get; set; }

        [BsonElement("name")]
        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        public required string Name { get; set; }

        [BsonElement("description")]
        /// <summary>
        /// Gets or sets the description of the genre.
        /// </summary>
        public string? Description { get; set; }

        [BsonElement("createdAt")]
        /// <summary>
        /// Gets or sets the creation date of the genre record.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        /// <summary>
        /// Gets or sets the last update date of the genre record.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        [BsonElement("isActive")]
        /// <summary>
        /// Gets or sets a value indicating whether the genre is active.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }

}
