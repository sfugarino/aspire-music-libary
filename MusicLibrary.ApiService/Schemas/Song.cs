using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas;

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
