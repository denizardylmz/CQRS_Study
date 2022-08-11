using Database_Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Context;

public class CQRSDbContext : DbContext
{
    public CQRSDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }


    public override int SaveChanges()
    {
        var datas = ChangeTracker.Entries<Product>();

        foreach (var data in datas)
        {
            switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.Today;
                        break;

                };
        }
        
        return base.SaveChanges();
    }
}