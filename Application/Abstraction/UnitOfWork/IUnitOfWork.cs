using Application.Abstraction.Repositories;

namespace Application.Abstraction.UnitOfWork;

public interface IUnitOfWork
{
    public IGenericRepository<T> GenericRepository<T>() where T : class;

    public Task SaveAsync();
}