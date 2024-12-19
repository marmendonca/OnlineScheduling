using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;
using Refit;

namespace OnlineScheduling.Api.Extensions;

public static class RegisterClients
{
    public static void AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        AddEfiBankClients(services, configuration);
    }

    private static void AddEfiBankClients(IServiceCollection services, IConfiguration configuration)
    {
        var efiBankAddress = configuration["EfiBankCredentials:BaseAddress"];
        var certificate = new X509Certificate2(configuration["EfiBankCredentials:CertificatePath"]!, (string)null, X509KeyStorageFlags.MachineKeySet);
            
        services.AddRefitClient<IEfiBankAuthClient>().ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(efiBankAddress!);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{configuration["EfiBankCredentials:ClientId"]}:{configuration["EfiBankCredentials:ClientSecret"]}")));
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ClientCertificates = { certificate }
        });

        services.AddRefitClient<IEfiBankChargeClient>().ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri(efiBankAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ClientCertificates = { certificate },
        });
    }
}