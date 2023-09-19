using TENANTFRAMEWORK.Infrastructure.TenantSupport;

namespace TENANTFRAMEWORK.Persistence.EF.SQL.Infrastructure;

public class MigrationsTenantProvider : ITenantProvider
{
    public string? CurrentTenant => null;

    public string DbSchemaName => "dbo";

    public string ConnectionString => "Persist Security Info=True;Integrated Security=true;Server=.;Database=Edu90;";

    public IDisposable BeginScope(string tenant)
    {
        throw new NotImplementedException();
    }
}
