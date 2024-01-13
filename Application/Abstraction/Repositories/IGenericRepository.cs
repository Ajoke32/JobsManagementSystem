namespace Application.Abstraction.Repositories;

public interface IGenericRepository<TEntity>
    :IDataReaderRepository<TEntity>,
     IDataModifierRepository<TEntity>
     where TEntity:class { }