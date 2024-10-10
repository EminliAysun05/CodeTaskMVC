using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Podcast.BLL.Services;

public class SpeakerManager : CrudManager<Speaker, SpeakerViewModel, SpeakerCreateViewModel, SpeakerUpdateViewModel>, ISpeakerService
{
    private readonly IRepositoryAsync<Speaker> _repository;
    private readonly IProfessionService _professionService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly ISpeakerProfessionService _speakerProfessionService;
    private readonly IMapper _mapper;

    public SpeakerManager(IRepositoryAsync<Speaker> repository, IMapper mapper, IProfessionService professionService, ICloudinaryService cloudinaryService, ISpeakerProfessionService speakerProfessionService) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _professionService = professionService;
        _cloudinaryService = cloudinaryService;
        _speakerProfessionService = speakerProfessionService;
    }

    public override Task<SpeakerViewModel?> GetAsync(Expression<Func<Speaker, bool>> predicate, Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null, Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null)
    {
        return base.GetAsync(predicate, include, orderBy);
    }

    public async Task<SpeakerCreateViewModel> GetSpeakerCreateViewModelAsync(SpeakerCreateViewModel createModel)
    {
        var professionList = await _professionService.GetListAsync();
        var professionSelectListItems = new List<SelectListItem>();

        professionList.ToList().ForEach(x => professionSelectListItems.Add(new SelectListItem(x.Name, x.Id.ToString())));
        createModel.Professions = professionSelectListItems;
        
        return createModel;
    }

    public override async Task<SpeakerViewModel> CreateAsync(SpeakerCreateViewModel createViewModel)
    {
        var speakerEntity = _mapper.Map<Speaker>(createViewModel);

        var createImageUrl = await _cloudinaryService.ImageCreateAsync(createViewModel.ImageFile);
        speakerEntity.ImageUrl = createImageUrl;

        var createdSpeaker = await _repository.CreateAsync(speakerEntity);

        return _mapper.Map<SpeakerViewModel>(createdSpeaker);
    }

    public async Task<SpeakerUpdateViewModel> GetSpeakerUpdateViewModelAsync(int id)
    {
        var speakerEntity = await _repository.GetAsync(x => x.Id == id, x => x.Include(y => y.SpeakerProfessions!).ThenInclude(z => z.Profession!));
        
        var oldProfessionSelectListItems = new List<SelectListItem>();
        speakerEntity?.SpeakerProfessions?.ForEach(sp => oldProfessionSelectListItems.Add(new SelectListItem(sp.Profession?.Name, sp.Profession?.Id.ToString())));

        var allProfessionList = await _professionService.GetListAsync();
        var newProfessionSelectListItems = new List<SelectListItem>();

        foreach (var item in allProfessionList)
        {
            if (oldProfessionSelectListItems.Any(x => x.Value == item.Id.ToString()))
                continue;

            newProfessionSelectListItems.Add(new SelectListItem(item.Name, item.Id.ToString()));
        }

        var updateModel = new SpeakerUpdateViewModel
        {
            Name = speakerEntity!.Name,
            OldProfessions = oldProfessionSelectListItems,
            NewProfessions = newProfessionSelectListItems
        };

        return updateModel;
    }

    public async override Task<SpeakerViewModel> UpdateAsync(SpeakerUpdateViewModel updateViewModel)
    {
        var existSpeaker = await _repository.GetAsync(updateViewModel.Id);

        if (existSpeaker == null) throw new ArgumentNullException(nameof(existSpeaker));

        existSpeaker = _mapper.Map(updateViewModel, existSpeaker);

        if (updateViewModel.ImageFile != null)
        {
            var createImageUrl = await _cloudinaryService.ImageCreateAsync(updateViewModel.ImageFile);
            existSpeaker.ImageUrl = createImageUrl;
        }

        foreach (var professionId in updateViewModel.OldProfessionIds ?? [])
        {
            var deletedRelationId = await _speakerProfessionService.GetAsync(x => x.SpeakerId == updateViewModel.Id && x.ProfessionId == professionId);

            if (deletedRelationId == null) continue;

            await _speakerProfessionService.RemoveAsync(deletedRelationId.Id);
        }

        foreach (var professionId in updateViewModel.NewProfessionIds ?? [])
        {
            await _speakerProfessionService.CreateAsync(new SpeakerProfessionCreateViewModel { ProfessionId = professionId, SpeakerId = updateViewModel.Id });
        }

        var result = await _repository.UpdateAsync(existSpeaker);

        return _mapper.Map<SpeakerViewModel>(result);
    }
}