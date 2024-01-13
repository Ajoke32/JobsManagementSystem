using System.Linq.Expressions;

namespace Application.Abstraction.Repositories;

public interface IDataReaderRepository<TEntity> where TEntity : class
{
    public Task<IQueryable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int? take = null, int? skip = null,
        string? includeProperties = null
    );

    public Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> func,
        string? includeProperties = null
    );
}