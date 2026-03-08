using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicLibrary.Domain.Schemas;

public abstract class Schema
{
        /// <summary>
    /// Gets or sets the unique identifier for the song.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


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