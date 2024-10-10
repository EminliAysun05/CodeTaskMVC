using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface IEpisodeService : ICrudService<Episode, EpisodeViewModel, EpisodeCreateViewModel, EpisodeUpdateViewModel>
{
    Task<EpisodeCreateViewModel> GetEpisodeCreateViewModelAsync(EpisodeCreateViewModel model);
    Task<EpisodeUpdateViewModel> GetEpisodeUpdateViewModelAsync(int id);
}
