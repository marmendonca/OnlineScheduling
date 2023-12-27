using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;

namespace OnlineScheduling.Api.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddRepositories<TImplementation>(this IServiceCollection services)
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
}   