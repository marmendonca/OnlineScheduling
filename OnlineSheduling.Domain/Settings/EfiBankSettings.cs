namespace OnlineScheduling.Domain.Settings;

public record EfiBankSettings
{
    public string ClientId { get; init; }
    public string ClientSecret { get; init; }
    public string RandomKey { get; init; }
    public string CertificatePath { get; init; }
    public string BaseAddress { get; init; }
}