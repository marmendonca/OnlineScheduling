using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Settings;

namespace OnlineScheduling.Infra.Services.v1;

public class EfiBankService(IOptions<EfiBankSettings> options, IEfiBankAuthClient authClient) : IEfiBankService
{
    private readonly EfiBankSettings _settings = options.Value;
        
    public async Task CreateImmediateChargeAsync(Customer customer)
    {
        var solicitationPayment = Guid.NewGuid().ToString();

        var token = await GetTokenAsync();
            
    }

    private async Task<string> GetTokenAsync()
    {
        var response = await authClient.LoginAsync(new LoginRequest());
            
        if (response is null || string.IsNullOrWhiteSpace(response.access_token))
            throw new Exception("Error on getting token from EfiBank");
            
        return response.access_token;
    }
}