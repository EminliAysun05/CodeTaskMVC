using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class CrudManager<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> : ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> 
    where TEntity : Entity
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
{
    private readonly IRepositoryAsync<TEntity> _repository;
    private readonly IMapper _mapper;

    public CrudManager(IRepositoryAsync<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TViewModel?> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        var viewModel = _mapper.Map<TViewModel>(entity);

        return viewModel;
    }

    public virtual async Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var entity = await _repository.GetAsync(predicate, include, orderBy);

        var viewModel = _mapper.Map<TViewModel>(entity);

        return viewModel;
    }

    public virtual async Task<IEnumerable<TViewModel>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var entityList = await _repository.GetListAsync(predicate, include, orderBy);

        var viewModelList = _mapper.Map<List<TViewModel>>(entityList);

        return viewModelList;
    }

    public virtual async Task<TViewModel> CreateAsync(TCreateViewModel createViewModel)
    {
        var entity = _mapper.Map<TEntity>(createViewModel);

        var createdEntity =  await _repository.CreateAsync(entity);   

        var viewModel = _mapper.Map<TViewModel>(createdEntity);

        return viewModel;
    }

    public virtual async Task<TViewModel> UpdateAsync(TUpdateViewModel updateViewModel)
    {
        var entity = _mapper.Map<TEntity>(updateViewModel);

        var updatedEntity = await _repository.UpdateAsync(entity);

        var viewModel = _mapper.Map<TViewModel>(updatedEntity);

        return viewModel;
    }

    public virtual async Task<TViewModel> RemoveAsync(int id)
    {
        var entity = await _repository.GetAsync(id);

        if (entity == null) throw new Exception("Not found");

        var deletedEntity = await _repository.RemoveAsync(entity);

        var viewModel = _mapper.Map<TViewModel>(deletedEntity);

        return viewModel;
    }
}
