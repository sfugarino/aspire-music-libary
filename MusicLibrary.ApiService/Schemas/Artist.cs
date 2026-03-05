using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.ApiService.Schemas;

/// <summary>
/// Represents an artist in the music library.
/// </summary>
public class Artist
{

    /// <summary>
    /// Gets or sets the unique identifier for the artist.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    /// <summary>
    /// Gets or sets the name of the artist.
    /// </summary>
    [BsonElement("name")]
    public required string Name { get; set; }


    /// <summary>
    /// Gets or sets the biography of the artist.
    /// </summary>
    [BsonElement("bio")]
    public string? Bio { get; set; }


    /// <summary>
    /// Gets or sets the origin of the artist.
    /// </summary>
    [BsonElement("origin")]
    public string? Origin { get; set; }


    /// <summary>
    /// Gets or sets the image URL of the artist.
    /// </summary>
    [BsonElement("image")]
    public string? Image { get; set; }


    /// <summary>
    /// Gets or sets the birth date of the artist.
    /// </summary>
    [BsonElement("birthDate")]
    public DateOnly? BirthDay { get; set; }


    /// <summary>
    /// Gets or sets the list of genre IDs associated with the artist.
    /// </summary>
    [BsonElement("genres")]
    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Genres { get; set; } = [];


    /// <summary>
    /// Gets or sets the creation date of the artist record.
    /// </summary>
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }


    /// <summary>
    /// Gets or sets the last update date of the artist record.
    /// </summary>
    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }


    /// <summary>
    /// Gets or sets a value indicating whether the artist is active.
    /// </summary>
    [BsonElement("isActive")]
    public bool IsActive { get; set; } = true;
}
