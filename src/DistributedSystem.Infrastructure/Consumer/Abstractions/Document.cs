using MongoDB.Bson;

namespace DistributedSystem.Infrastructure.Consumer.Abstractions;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }
    public string DocumentId { get; set; } // Id Source Message
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
}