namespace OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;

public record LoginRequest
{
    public string grant_type { get; init; } = "client_credentials";
}