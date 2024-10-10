using Microsoft.EntityFrameworkCore.Query;
using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.DAL.Repositories.Contracts;

public interface IRepositoryAsync<T> where T : Entity
{
    Task<T?> GetAsync(int id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate,
                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, 
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
}
