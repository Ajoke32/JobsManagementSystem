using Application.Abstraction.Factories;
using Application.Abstraction.Repositories;
using Application.Abstraction.UnitOfWork;
using Infrastructure.Factories;
using Infrastructure.Persistence.ApplicationContext;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork(IGenericRepositoryFactory factory, DbContext context) : IUnitOfWork
{
    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return factory.CreateInstance<T>();
    }

    public Task SaveAsync()
    {
        try
        {
            return context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}