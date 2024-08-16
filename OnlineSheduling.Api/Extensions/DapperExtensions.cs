using System;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.DependencyInjection;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Api.Extensions;

public static class DapperExtensions
{
    public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IDapperContext>((Func<IServiceProvider, IDapperContext>) (provider => (IDapperContext) new DapperContext(connectionString)));
        DapperExtensions.TableNameResolver();
        return services;
    }

    private static void TableNameResolver()
    {
        SqlMapperExtensions.TableNameMapper = (SqlMapperExtensions.TableNameMapperDelegate) (type => type.Name);
    }
}