using Amazon.S3;
using DbMigration.Domain.Models;
using DbMigration.Infrastructure.Extensions;
using DbMigration.Persistence.EF.SQL;
using DbMigration.Persistence.EF.SQL.Extensions;
using DbMigration.Website.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DbMigration.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddAWSService<IAmazonS3>();
            builder.Services
                .AddTenantSupport(builder.Configuration)
                .AddEntityFrameworkSqlServer<DashboardDbContext>();


            builder.Services.AddIdentity<Profile, IdentityRole>()
                        .AddEntityFrameworkStores<DashboardDbContext>();

            builder.Services.AddRazorPages();

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

            app.Run();
        }
    }
}