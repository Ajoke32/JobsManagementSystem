using Application.Abstraction.Factories;
using Application.Abstraction.Repositories;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Factories;

public class RepositoryFactory(DbContext context) : IGenericRepositoryFactory
{
    public IGenericRepository<TRepos> CreateInstance<TRepos>() where TRepos : class
    {
        return new GenericRepository<TRepos>(context);
    }
}