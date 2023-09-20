
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using UniversalJurayEop.Infrastructure.TenantSupport;
using UniversalJurayEop.Domain.Models;
using UniversalJurayEop.Application.Interfaces;
using UniversalJurayEop.Domain.Common;

namespace UniversalJurayEop.Infrastructure.Context;

public class AppDbContext : IdentityDbContext<Profile, IdentityRole, string>
{
    private readonly IDateTimeService _dateTime;
    private readonly IAuthenticatedUserService _authenticatedUser;
    private readonly ITenantProvider _tenantProvider;


    //public DbSet<--> -- { get; set; } = null!;
    public DbSet<Food> Foods { get; set; }


    public AppDbContext(DbContextOptions options, ITenantProvider tenantProvider, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
    {
        _tenantProvider = tenantProvider;
        _dateTime = dateTime;
        _authenticatedUser = authenticatedUser;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _tenantProvider.ConnectionString,
            o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, /*_tenantProvider.DbSchemaName*/null));
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTime.NowUtc;
                    entry.Entity.CreatedBy = _authenticatedUser.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = _dateTime.NowUtc;
                    entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
//public class AppDbContext : IdentityDbContext<Profile, IdentityRole, string>
//{
//    private readonly IDateTimeService _dateTime;
//    private readonly IAuthenticatedUserService _authenticatedUser;
//    private readonly ITenantProvider _tenantProvider;
//    public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
//    {
//        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
//        _dateTime = dateTime;
//        _authenticatedUser = authenticatedUser;
//        _tenantProvider = tenantProvider;
//    }
//    public DbSet<Food> Foods { get; set; }

//    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
//    {
//        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
//        {
//            switch (entry.State)
//            {
//                case EntityState.Added:
//                    entry.Entity.Created = _dateTime.NowUtc;
//                    entry.Entity.CreatedBy = _authenticatedUser.UserId;
//                    break;
//                case EntityState.Modified:
//                    entry.Entity.LastModified = _dateTime.NowUtc;
//                    entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
//                    break;
//            }
//        }
//        return base.SaveChangesAsync(cancellationToken);
//    }
//    protected override void OnModelCreating(ModelBuilder builder)
//    {
//        //All Decimals will have 18,6 Range
//        foreach (var property in builder.Model.GetEntityTypes()
//        .SelectMany(t => t.GetProperties())
//        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
//        {
//            property.SetColumnType("decimal(18,6)");
//        }
//        base.OnModelCreating(builder);
//    }
//}
