using UniversalJurayEop.Infrastructure.TenantSupport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversalJurayEop.Application.Interfaces;
using UniversalJurayEop.Infrastructure.Repositories;
using UniversalJurayEop.Application.Interfaces.Repositories;

namespace UniversalJurayEop.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTenantSupport(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITenantProvider, TenantProvider>();

        // Configure TenantConfigurationOptions using the configuration section
        services.Configure<TenantConfigurationOptions>(options =>
        {
            configuration.GetSection(TenantConfigurationOptions.ConfigKey).Bind(options);
        });
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IFoodRepositoryAsync, FoodRepositoryAsync>();
        return services;
    }

}
