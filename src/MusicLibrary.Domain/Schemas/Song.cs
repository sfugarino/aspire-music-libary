using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Schemas;

/// <summary>
/// Represents a song in the music library.
/// </summary>
public class Song : Schema
{

    /// <summary>
    /// Gets or sets the title of the song.
    /// </summary>
    [BsonElement("title")]
    public required string Title { get; set; }


    /// <summary>
    /// Gets or sets the artist ID for the song (references Artist).
    /// </summary>
    [BsonElement("artists")]
    [BsonRepresentation(BsonType.ObjectId)]
    public required List<string> Artists { get; set; } = []; // references Artist
    
    /// <summary>
    /// Gets or sets list of albums that the song appears on album
    /// </summary>
    [BsonElement("albums")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Albums { get; set; } = []; // references Album

    /// <summary>
    /// Gets or sets the duration of the song in seconds.
    /// </summary>
    [BsonElement("duration")]
    public int? Duration { get; set; } // seconds


    /// <summary>
    /// Gets or sets the list of genre IDs associated with the song (references Genre).
    /// </summary>
    [BsonElement("genres")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Genres { get; set; } = []; // references Genre

    /// <summary>
    /// Gets the detailed genre information associated with the artist.
    /// </summary>
    [BsonIgnore]
    public IEnumerable<Genre> GenreDetails { get; set; } = [];

    /// <summary>
    /// Gets or sets the audio file URL of the song.
    /// </summary>
    [BsonElement("audioFile")]
    public string? AudioFile { get; set; }
    

    /// <summary>
    /// Gets or sets the lyrics of the song.
    /// </summary>
    [BsonElement("lyrics")]
    public string? Lyrics { get; set; }


}
