﻿using TENANTFRAMEWORK.Infrastructure.TenantSupport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TENANTFRAMEWORK.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantSupport(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITenantProvider, TenantProvider>();
        services.Configure<TenantConfigurationOptions>(configuration.GetSection(TenantConfigurationOptions.ConfigKey));

        return services;
    }
}
