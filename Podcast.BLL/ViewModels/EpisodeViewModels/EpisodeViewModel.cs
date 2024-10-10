using Podcast.BLL.ViewModels.SpeakerViewModels;
using Podcast.BLL.ViewModels.TopicViewModels;

namespace Podcast.BLL.ViewModels.EpisodeViewModels;

public class EpisodeViewModel : IViewModel
{
    public int Id {  get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? CoverUrl { get; set; }
    public string? MusicUrl { get; set; }
    public int ViewCount { get; set; }
    public int DownloadCount { get; set; }
    public int LikeCount { get; set; }
    public int DurationInMinute { get; set; }
    public SpeakerViewModel? Speaker { get; set; }
    public TopicViewModel? Topic { get; set; }
}
