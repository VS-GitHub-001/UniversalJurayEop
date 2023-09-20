using System.Reflection.Metadata;
using DbMigration.Infrastructure.TenantSupport;

namespace DbMigration.Website.Middlewares;
//https://github.com/Oriflame/DbMigration#multiple-databases---complete-data-isolation
public class TenantScopeMiddleware
{
    private readonly RequestDelegate _next;

    public TenantScopeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, ITenantProvider tenantProvider)
    {
         
        // Got htis code from  http://blog.gaxion.com/2017/05/how-to-implement-multi-tenancy-with.html
        var GetAddress = httpContext.Request.Headers["Host"];

        var tenant = GetAddress[0];
        tenant = tenant.Replace("www.", "");
        tenant = tenant.Replace("https://", "");

 
  if (tenant.ToString().ToLower() == "localhost:7143")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }else if (tenant.ToString().ToLower() == "enugudashboard.exwhyzee.ng")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        else if (tenant.ToString().ToLower() == "school2.exwhyzee.ng")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        else if (tenant.ToString().ToLower() == "school3.sec44nipss.com")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        else if (tenant.ToString().ToLower() == "school4.exwhyzee.ng")//;Initial Catalog=;User Id=
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;
        }
        else if (tenant.ToString().ToLower() == "school5.dmmmg.org")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        else if (tenant.ToString().ToLower() == "site6.dmmmg.org")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        


        await _next(httpContext);
    }
}

/// <summary>
/// Extension method used to add the middleware to the HTTP request pipeline.
/// </summary>
public static class TenantScopeMiddlewareExtensions
{
    public static IApplicationBuilder UseTenantScopeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TenantScopeMiddleware>();
    }
}
