using System.Reflection.Metadata;
using UniversalJurayEop.Infrastructure.TenantSupport;

namespace UniversalJurayEop.Represenation.Middlewares;
//https://github.com/Oriflame/UniversalJurayEop#multiple-databases---complete-data-isolation
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


        if (tenant.ToString().ToLower() == "localhost:7227")
        {
            using var scope = tenantProvider.BeginScope(tenant);
            await _next(httpContext);

            return;

        }
        else if (tenant.ToString().ToLower() == "a.exwhyzee.ng")
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
