using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.ProfessionViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface IProfessionService : ICrudService<Profession, ProfessionViewModel, ProfessionCreateViewModel, ProfessionUpdateViewModel>
{
}
