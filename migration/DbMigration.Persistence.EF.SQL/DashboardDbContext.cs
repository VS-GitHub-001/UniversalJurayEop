using DbMigration.Domain; 
using DbMigration.Infrastructure.TenantSupport;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using DbMigration.Domain.Models;

namespace DbMigration.Persistence.EF.SQL;

public class DashboardDbContext : IdentityDbContext<Profile, IdentityRole, string>
{
    private readonly ITenantProvider _tenantProvider;

 
    //public DbSet<--> -- { get; set; } = null!;
    public DbSet<Food> Foods { get; set; }

    public DashboardDbContext(DbContextOptions options, ITenantProvider tenantProvider) : base(options)
    {
        _tenantProvider = tenantProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _tenantProvider.ConnectionString,
            o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, /*_tenantProvider.DbSchemaName*/null));
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<string>()
            .HaveMaxLength(255);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema(_tenantProvider.DbSchemaName);   // set schema

        base.OnModelCreating(modelBuilder);

        // ConfigureCustomer(modelBuilder);
    }

    //private static void ConfigureCustomer(ModelBuilder builder)
    //{
    //    builder.Entity<Customer>(b =>
    //    {
    //        var table = b.ToTable("Customers");

    //        table.Property(p => p.CustomerId).ValueGeneratedOnAdd();
    //        table.HasKey(p => p.CustomerId).HasName("PK_CustomerId");
    //    });
    //}
}
