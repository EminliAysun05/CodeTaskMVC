using Podcast.BLL.ViewModels.SpeakerProfessionViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.Services.Contracts;

public interface ISpeakerProfessionService : ICrudService<SpeakerProfession, SpeakerProfessionViewModel, SpeakerProfessionCreateViewModel, SpeakerProfessionUpdateViewModel>
{

}