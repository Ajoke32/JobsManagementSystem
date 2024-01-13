using Application.Abstraction.Factories;
using Application.Abstraction.UnitOfWork;
using Infrastructure.Factories;
using Infrastructure.Persistence.ApplicationContext;
using Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection collection)
    {
        collection.AddDbContext<DbContext,AppDbContext>((serv,config) =>
        {
            var configuration = serv.GetRequiredService<IConfiguration>();
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        collection.AddScoped<IUnitOfWork, UnitOfWork>();
        collection.AddScoped<IGenericRepositoryFactory, RepositoryFactory>();
    }
}