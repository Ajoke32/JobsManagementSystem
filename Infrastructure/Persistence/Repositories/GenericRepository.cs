using System.Linq.Expressions;
using Application.Abstraction.Repositories;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity:class
{
    private readonly DbContext _context;

    private readonly DbSet<TEntity> _dbSet;
    
    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int? take = null, int? skip = null,
        string? includeProperties = null)
    {
        IQueryable<TEntity> query = _dbSet;
        
        try
        {
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                query.IncludeStringProperties(includeProperties);
            }
            
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (skip != null)
            {
                query = query.Skip((int)skip);
            }

            if (take != null)
            {
                query = query.Take((int)take);
            }
            
            return query;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> func, string? includeProperties = null)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
            {
               query.IncludeStringProperties(includeProperties);
            }

            
            return await query.FirstOrDefaultAsync(func);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public ValueTask<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            var md = _dbSet.Add(entity);
            return new ValueTask<TEntity>(md.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<bool> DeleteAsync(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var en = _dbSet.Update(entity);
        _context.Entry(en).State = EntityState.Modified;
        return new ValueTask<TEntity>(en.Entity);
    }
}