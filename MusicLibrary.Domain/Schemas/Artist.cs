using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MusicLibrary.Domain.Schemas;

/// <summary>
/// Represents an artist in the music library.
/// </summary>
[BsonIgnoreExtraElements]
public class Artist : Schema
{

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
    /// Gets the detailed genre information associated with the artist.
    /// </summary>
    //[BsonIgnore]
    public IEnumerable<Genre> GenreDetails { get; set; } = [];

}
