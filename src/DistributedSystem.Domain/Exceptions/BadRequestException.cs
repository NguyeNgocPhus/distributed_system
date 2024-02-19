namespace DistributedSystem.Domain.Exceptions;

public class BadRequestException : DomainException
{
    public BadRequestException(string title, string message) : base(title, message)
    {
    }
}