using AutoMapper;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerProfessionViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.BLL.Services;

public class SpeakerProfessionManager : CrudManager<SpeakerProfession, SpeakerProfessionViewModel, SpeakerProfessionCreateViewModel, SpeakerProfessionUpdateViewModel>, ISpeakerProfessionService
{
    public SpeakerProfessionManager(IRepositoryAsync<SpeakerProfession> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}