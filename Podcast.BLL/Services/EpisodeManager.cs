using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.BLL.Services;

public class EpisodeManager : CrudManager<Episode, EpisodeViewModel, EpisodeCreateViewModel, EpisodeUpdateViewModel>, IEpisodeService
{
    private readonly ISpeakerService _speakerService;
    private readonly ITopicService _topicService;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IMapper _mapper;
    private readonly IRepositoryAsync<Episode> _repository;

    public EpisodeManager(IRepositoryAsync<Episode> repository, IMapper mapper, ISpeakerService speakerService, ITopicService topicService, ICloudinaryService cloudinaryService) : base(repository, mapper)
    {
        _speakerService = speakerService;
        _topicService = topicService;
        _cloudinaryService = cloudinaryService;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<EpisodeCreateViewModel> GetEpisodeCreateViewModelAsync(EpisodeCreateViewModel model)
    {
        var speakerList = await _speakerService.GetListAsync();
        var speakerSelectListItems  = new List<SelectListItem>();

        foreach (var speaker in speakerList)
        {
            speakerSelectListItems.Add(new SelectListItem(speaker.Name, speaker.Id.ToString()));
        }

        var topicList = await _topicService.GetListAsync();
        var topicSelectListItems = new List<SelectListItem>();

        foreach (var topic in topicList)
        {
            topicSelectListItems.Add(new SelectListItem(topic.Name, topic.Id.ToString()));
        }

        model.Speakers = speakerSelectListItems;
        model.Topics = topicSelectListItems;

        return model;
    }

    public Task<EpisodeUpdateViewModel> GetEpisodeUpdateViewModelAsync(int id)
    {
        throw new NotImplementedException();
    }

    //public override async Task<EpisodeViewModel> CreateAsync(EpisodeCreateViewModel createViewModel)
    //{
    //    var episodeEntity = _mapper.Map<Episode>(createViewModel);

    //    var createdImageUrl = await _cloudinaryService.FileCreateAsync(createViewModel.CoverFile);
    //    episodeEntity.CoverUrl = createdImageUrl;

    //    var createdMusicUrl = await _cloudinaryService.FileCreateAsync(createViewModel.MusicFile);
    //    episodeEntity.MusicUrl = createdMusicUrl;

    //    var result = await _repository.CreateAsync(episodeEntity);

    //    return _mapper.Map<EpisodeViewModel>(result);
    //}

    public override async Task<EpisodeViewModel> CreateAsync(EpisodeCreateViewModel createViewModel)
    {
        var createdImageUrl = await _cloudinaryService.ImageCreateAsync(createViewModel.CoverFile);
        createViewModel.CoverUrl = createdImageUrl;

        var createdMusicUrl = await _cloudinaryService.AudioCreateAsync(createViewModel.MusicFile);
        createViewModel.MusicUrl = createdMusicUrl;

        return await base.CreateAsync(createViewModel);
    }
}
