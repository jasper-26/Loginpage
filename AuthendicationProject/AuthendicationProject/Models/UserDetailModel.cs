using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LoginProject.Models;

public class UserDetailModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Username")]
    [JsonPropertyName("Username")]
    public string? Username { get; set; }

    [BsonElement("Password")]
    [JsonPropertyName("Password")]
    public string? Password { get; set; }

    public DateTime? LastActivity { get; set; }
}

