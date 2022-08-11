using BusinessLayer.Context;
using BusinessLayer.CQRS.Handlers.CommandHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer;

public class BusinessServiceRegistration
{
    public static void AddBusinessRegistration(IServiceCollection collection)
    {
        collection.AddDbContext<CQRSDbContext>(options => 
            options.UseSqlite(Configurations.ConnectionString));
        collection.AddTransient<CreateProductCommandHandler>();
        collection.AddMediatR(typeof(CQRSDbContext));
    }
}