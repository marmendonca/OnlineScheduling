using Dapper.Contrib.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineScheduling.Application.Commands.v1.Schedules.Create;
using OnlineScheduling.Application.Mappers;
using OnlineScheduling.Application.Queries.v1.Schedules.GetById;
using OnlineScheduling.Application.Services.v1;
using OnlineScheduling.Application.Services.v1.Interfaces;
using OnlineScheduling.Domain.Contracts.Repositories;
using OnlineScheduling.Infra.Context;
using Scrutor;

namespace OnlineScheduling.Application.Modules;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDapper(configuration);
        service.AddRepositories<DataContext>();
        service.AddClients(configuration);
        service.AddServices();
        service.AddAutoMapperConfiguration();
        service.AddValidators();
        service.AddMediatRConfiguration();
            
        return service;
    }
        
    private static IServiceCollection AddDapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDapperContext>((Func<IServiceProvider, IDapperContext>) (provider => (IDapperContext) new DapperContext(configuration.GetSection("DefaultConnection").Value)));
        TableNameResolver();
        return services;
    }

    private static IServiceCollection AddRepositories<TImplementation>(this IServiceCollection services)
    {
        services.Scan(delegate (ITypeSourceSelector scan)
        {
            scan.FromAssemblyOf<TImplementation>().AddClasses(delegate (IImplementationTypeFilter x)
                {
                    x.Where((Type t) => t.Name.EndsWith("Repository"));
                }).AsImplementedInterfaces()
                .UsingRegistrationStrategy(RegistrationStrategy.Replace(ReplacementBehavior.ImplementationType))
                .AsMatchingInterface()
                .WithScopedLifetime();
        });

        return services;
    }
        
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEfiBankService, EfiBankService>();
    }
        
    private static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CustomerProfile));
    }
        
    private static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateScheduleCommandValidator>();
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }
        
    private static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(config => config
            .RegisterServicesFromAssemblies(typeof(CreateScheduleCommand).Assembly, typeof(GetScheduleByIdQuery).Assembly));
    }

    private static void TableNameResolver()
    {
        SqlMapperExtensions.TableNameMapper = (SqlMapperExtensions.TableNameMapperDelegate) (type => type.Name);
    }
}