namespace DistributedSystem.Contract.Services.V1.Identity;

public static class Response
{
    public record Authenticated(string AccessToken, string RefreshToken, DateTime RefreshTokenExpiryTime);
}