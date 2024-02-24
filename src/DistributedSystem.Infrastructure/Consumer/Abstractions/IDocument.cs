using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DistributedSystem.Infrastructure.Consumer.Abstractions;

public interface IDocument
{
    [BsonId]
    ObjectId Id { get; set; }
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset? ModifiedAt { get; set; }
}