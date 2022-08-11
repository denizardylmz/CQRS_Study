using BusinessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusinessLayer;

public class DesignTimeDbContext : IDesignTimeDbContextFactory<CQRSDbContext>
{
    public CQRSDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<CQRSDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<CQRSDbContext>();
        dbContextOptionsBuilder.UseSqlite(Configurations.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}