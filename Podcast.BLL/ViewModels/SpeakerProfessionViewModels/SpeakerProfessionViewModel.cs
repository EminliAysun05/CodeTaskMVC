using Podcast.BLL.ViewModels.ProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;

namespace Podcast.BLL.ViewModels.SpeakerProfessionViewModels;

public class SpeakerProfessionViewModel : IViewModel
{
    public int Id { get; set; }
    public SpeakerViewModel? Speaker { get; set; }
    public ProfessionViewModel? Profession { get; set; }
}
