using System;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Authorization.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddCustomAuthorizationPolicy(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddAuthorization(x =>
            {
                x.AddPolicy("CustomPolicy", y => y.RequireClaim("CustomClaim"));
            });

        return services;
    }
}