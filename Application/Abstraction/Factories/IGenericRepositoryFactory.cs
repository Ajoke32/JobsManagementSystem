using Application.Abstraction.Repositories;

namespace Application.Abstraction.Factories;

public interface IGenericRepositoryFactory
{
    public IGenericRepository<TRepos> CreateInstance<TRepos>()
        where TRepos : class;
}