using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.BLL.ViewModels.TopicViewModels;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.BLL.UI.ViewModels;

public class HomeViewModel
{
    public List<SpeakerViewModel> Speakers { get; set; } = [];
    public List<EpisodeViewModel> Episodes { get; set; } = [];
    public List<TopicViewModel> Topics { get; set; } = [];
    public List<Profession> Professions { get; set; } = [];
}
