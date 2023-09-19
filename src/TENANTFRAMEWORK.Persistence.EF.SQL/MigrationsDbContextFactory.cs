﻿using TENANTFRAMEWORK.Persistence.EF.SQL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TENANTFRAMEWORK.Persistence.EF.SQL;

public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<DashboardDbContext>
{
    public DashboardDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<DashboardDbContext>();

        return new DashboardDbContext(builder.Options, new MigrationsTenantProvider());
    }
}
