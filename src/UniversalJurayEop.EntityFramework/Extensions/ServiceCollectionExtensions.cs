using UniversalJurayEop.Infrastructure.TenantSupport; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace UniversalJurayEop.EntityFramework.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkSqlServer<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
      
        services.TryAddSingleton<ITenantProvider, TenantProvider>();

        services
            .AddEntityFrameworkSqlServer()
            .AddDbContext<TContext>((sp, options) =>
                options.UseInternalServiceProvider(sp)
            );

        return services;
    }
}
