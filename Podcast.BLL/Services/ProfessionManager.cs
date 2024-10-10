using AutoMapper;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.ProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.BLL.Services;

public class ProfessionManager : CrudManager<Profession, ProfessionViewModel, ProfessionCreateViewModel, ProfessionUpdateViewModel>, IProfessionService
{

    public ProfessionManager(IRepositoryAsync<Profession> professionRepository, IMapper mapper) : base(professionRepository, mapper)
    {
    }
}
