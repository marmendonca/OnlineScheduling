using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;
using Refit;

namespace OnlineScheduling.Api.Extensions;

public static class RegisterClients
{
    public static void AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        var efiBankAddress = configuration["EfiBankCredentials:BaseAddress"];
        var clientId = configuration["EfiBankCredentials:ClientId"];
        var clientSecret = configuration["EfiBankCredentials:ClientSecret"];
        var certificatePath = configuration["EfiBankCredentials:CertificatePath"];
        var certificate = new X509Certificate2(certificatePath, (string)null, X509KeyStorageFlags.MachineKeySet);
            
        services.AddRefitClient<IEfiBankAuthClient>().ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(efiBankAddress!);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", 
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
            })
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ClientCertificates = { certificate }
            });
    }
}

public class BasicAuthHandler(string username, string password) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            
        return base.SendAsync(request, cancellationToken);
    }
}