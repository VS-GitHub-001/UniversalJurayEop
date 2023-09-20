using Amazon.S3;
using Microsoft.AspNetCore.Identity;
using UniversalJurayEop.Application.Interfaces;
using UniversalJurayEop.Domain.Models;
using UniversalJurayEop.EntityFramework.Extensions;
using UniversalJurayEop.Infrastructure.Context;
using UniversalJurayEop.Infrastructure.Extensions;
using UniversalJurayEop.Infrastructure.Services;
using UniversalJurayEop.Represenation.Extensions;
using UniversalJurayEop.Represenation.Middlewares;
using UniversalJurayEop.Represenation.Services;

namespace UniversalJurayEop.Represenation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Configure services for Razor Pages
            builder.Services.AddRazorPages();

            // Configure services for Blazor
            builder.Services.AddServerSideBlazor();

            // Configure services for API endpoints
            builder.Services.AddControllers();
            // Add services to the container.

            builder.Services.AddAWSService<IAmazonS3>();
            builder.Services
                .AddTenantSupport(builder.Configuration)
            .AddEntityFrameworkSqlServer<AppDbContext>();


            builder.Services.AddIdentity<Profile, IdentityRole>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddApiVersioningExtension();
            builder.Services.AddHealthChecks();
            builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            builder.Services.AddScoped<IDateTimeService, DateTimeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseTenantScopeMiddleware();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapBlazorHub(); // Add Blazor hub endpoint for SignalR.

            // Map API endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map API controllers
            });

            app.Run();
        }
    }
}