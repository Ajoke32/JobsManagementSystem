namespace Application.Abstraction.Repositories;

public interface IDataModifierRepository<TEntity> where TEntity:class
{
    public ValueTask<TEntity> CreateAsync(TEntity entity);

    public Task<bool> DeleteAsync(TEntity entity);

    public ValueTask<TEntity> UpdateAsync(TEntity entity);
}