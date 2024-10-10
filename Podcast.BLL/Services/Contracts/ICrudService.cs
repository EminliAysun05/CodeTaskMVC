using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.ViewModels;
using Podcast.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Podcast.BLL.Services.Contracts;

public interface ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> 
    where TEntity : Entity 
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
{
    Task<TViewModel?> GetAsync(int id);

    Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
     Task<IEnumerable<TViewModel>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, 
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    Task<TViewModel> CreateAsync(TCreateViewModel createViewModel);
    Task<TViewModel> UpdateAsync(TUpdateViewModel entity);
    Task<TViewModel> RemoveAsync(int id);
}
