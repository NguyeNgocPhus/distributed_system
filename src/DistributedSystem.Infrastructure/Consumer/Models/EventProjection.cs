using DistributedSystem.Infrastructure.Consumer.Abstractions;
using DistributedSystem.Infrastructure.Consumer.Attributes;
using DistributedSystem.Infrastructure.Consumer.Constants;
using MongoDB.Bson;

namespace DistributedSystem.Infrastructure.Consumer.Models;

[BsonCollection(TableNames.Events)]
public class EventProjection : Document
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}