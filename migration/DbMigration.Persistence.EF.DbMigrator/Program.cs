using System.Reflection;
using DbMigration.Infrastructure.Extensions;
using DbMigration.Infrastructure.TenantSupport;
using DbMigration.Persistence.EF.DbMigrator;
using DbMigration.Persistence.EF.SQL;
using DbMigration.Persistence.EF.SQL.Extensions;
using Microsoft.Extensions.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(configBuilder =>
    {
        // need to set base path to make it work with shared appsettings files
        configBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location));
    })
    .ConfigureServices((hostContext, services) =>
    {
       // services.AddTenantSupport(hostContext.Configuration);
        services.AddATenantSupport(hostContext.Configuration);
        services.AddEntityFrameworkSqlServer<DashboardDbContext>();
        services.AddHostedService<DbMigratorHostedService>();
 
    })
    .Build();

await host.RunAsync();
