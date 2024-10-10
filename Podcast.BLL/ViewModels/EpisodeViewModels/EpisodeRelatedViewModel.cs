using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.ViewModels.EpisodeViewModels
{
    public class EpisodeRelatedViewModel
    {
        public EpisodeViewModel? SelectedEpisode { get; set; }
        public List<EpisodeViewModel>? RelatedEpisodes { get; set; }
    }
}
