using DistributedSystem.Contract.Abstractions.Messages;

namespace DistributedSystem.Contract.Services.V1.Identity;

public static class Command
{
    public record Login(string Email, string Password) : ICommand;
    public record Token(string AccessToken, string RefreshToken) : ICommand<Response.Authenticated>;
    
}