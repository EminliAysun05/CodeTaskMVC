using Microsoft.EntityFrameworkCore;
using Podcast.BLL.Data;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.UI.Services.Contracts;
using Podcast.BLL.UI.ViewModels;

namespace Podcast.BLL.UI.Services
{
    public class HomeManager : IHomeService
    {
        private readonly ISpeakerService _speakerService;
        private readonly IEpisodeService _episodeService;
        private readonly ITopicService _topicService;
        private readonly IFileService _fileService;

        public HomeManager(ISpeakerService speakerService, IEpisodeService episodeService, ITopicService topicService, IFileService fileService)
        {
            _speakerService = speakerService;
            _episodeService = episodeService;
            _topicService = topicService;
            _fileService = fileService;
        }

        public async Task<(byte[] fileContent, string fileContentType, string fileName)> Download(int id)
        {
            var episode = await _episodeService.GetAsync(id);

            if (episode == null) throw new Exception("Not found");

            var result = _fileService.Download(Constants.EpisodeImagePath, episode.CoverUrl);

            return result;
        }

        public async Task<HomeViewModel> GetHomeViewModel()
        {
            var speakerList = await _speakerService.GetListAsync(include: x => x.Include(y => y.SpeakerProfessions!).ThenInclude(z => z.Profession!));
            var topicList = await _topicService.GetListAsync(include: x => x.Include(y => y.Episodes!));
            var episodeList = await _episodeService.GetListAsync(include: x => x.Include(y => y.Speaker!).Include(y => y.Topic!));

            var viewModel = new HomeViewModel
            {
                Speakers = speakerList.ToList(),
                Episodes = episodeList.ToList(),
                Topics = topicList.ToList()
            };

            return viewModel;
        }
    }
}
