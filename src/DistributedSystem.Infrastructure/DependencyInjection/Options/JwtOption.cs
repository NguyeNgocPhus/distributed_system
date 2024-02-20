namespace DistributedSystem.Infrastructure.DependencyInjection.Options;

public class JwtOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public double ExpireMin { get; set; }
}