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

    /// <summary>
    /// Gets or sets the unique identifier for the song.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


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
    /// Gets or sets the audio file URL of the song.
    /// </summary>
    [BsonElement("audioFile")]
    public string? AudioFile { get; set; }
    

    /// <summary>
    /// Gets or sets the lyrics of the song.
    /// </summary>
    [BsonElement("lyrics")]
    public string? Lyrics { get; set; }


    /// <summary>
    /// Gets or sets the creation date of the song record.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }


    /// <summary>
    /// Gets or sets the last update date of the song record.
    /// </summary>
    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether the song is active.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
