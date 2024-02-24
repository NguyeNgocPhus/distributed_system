namespace DistributedSystem.Infrastructure.Consumer.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class BsonCollectionAttribute : Attribute
{
    public string CollectionName { get; set; }

    public BsonCollectionAttribute(string collectionName)
    {
        CollectionName = collectionName;
    }
}