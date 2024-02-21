namespace DistributedSystem.Persistence.Outbox;

public class OutboxMessage
{
    
    public Guid Id { get; set; }
    public DateTime OccurredOnUtc { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
    public DateTime? ProcessOnUtc { get; set; }
    public string? Error { get; set; }
   
}