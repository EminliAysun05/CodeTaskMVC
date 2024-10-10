using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.DAL.Repositories;

public class EfCoreRepository<T> : IRepositoryAsync<T> where T : Entity
{
    private readonly AppDbContext _dbContext;

    public EfCoreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetAsync(int id)
    {
       var result = await _dbContext.Set<T>().FindAsync(id);

        return result;
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        query = query.Where(predicate);

        return await query.FirstOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                                           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (include != null) query = include(query);

        if (orderBy != null) query = orderBy(query);

        if (predicate != null) query = query.Where(predicate);

        return  await query.ToListAsync();
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        var entityEntry = await _dbContext.Set<T>().AddAsync(entity);
       
        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> RemoveAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Remove(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entityEntry = _dbContext.Set<T>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }
}
