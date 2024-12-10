using Microsoft.Extensions.DependencyInjection;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Infra.Services.v1;

namespace OnlineScheduling.Api.Extensions;

public static class RegisterServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEfiBankService, EfiBankService>();
    }
}