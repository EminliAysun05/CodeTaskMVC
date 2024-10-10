using Podcast.BLL.ViewModels.ProfessionViewModels;

namespace Podcast.BLL.ViewModels.SpeakerViewModels;

public class SpeakerViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }

    public List<ProfessionViewModel>? Professions { get; set; }
}
