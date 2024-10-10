using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.UI.Services.Contracts;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using Podcast.BLL.ViewModels.SpeakerProfessionViewModels;
using Podcast.BLL.ViewModels.SpeakerViewModels;

namespace Podcast.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISpeakerService _speakerService;
        private readonly ISpeakerProfessionService _speakerProfessionService;
        private readonly IEpisodeService _episodeService;
        private readonly IAudioService _audioService;

        public HomeController(IHomeService homeService, IWebHostEnvironment webHostEnvironment, ISpeakerService speakerService, ISpeakerProfessionService speakerProfessionService, IAudioService audioService, IEpisodeService episodeService)
        {
            _homeService = homeService;
            _webHostEnvironment = webHostEnvironment;
            _speakerService = speakerService;
            _speakerProfessionService = speakerProfessionService;
            _audioService = audioService;
            _episodeService = episodeService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _homeService.GetHomeViewModel();

            return View(viewModel);
        }

        public async Task<IActionResult> Download(int? id)
        {
            if (id == null) return NotFound();

            var fileResult = await _homeService.Download(id.Value);

            return File(fileResult.fileContent, fileResult.fileContentType, fileResult.fileName);

            //var fileResult = _homeService.DownloadWithFileContent();

            //return File(fileResult.FileContents, fileResult.ContentType, fileResult.FileDownloadName);
        }


        public async Task<IActionResult> CreateSpeaker()
        {
            var speakerCreateViewModel = new SpeakerCreateViewModel
            { ImageFile = null, Name = "Ibrahim", ImageUrl = "3.jpg", ProfessionIds = [3] };

            var result = await _speakerService.CreateAsync(speakerCreateViewModel);

            return Json(result);
        }

        //public async Task<IActionResult> UpdateSpeaker()
        //{
        //    var speakerUpdateViewModel = new SpeakerUpdateViewModel
        //    { Id = 13, ImageFile = null, Name = "Aslan2", ImageUrl = "1.jpg", ProfessionIds = [1, 2, 3] };

        //    var result = await _speakerService.UpdateAsync(speakerUpdateViewModel);

        //    return Json(result);
        //}

        public async Task<IActionResult> CreateSpeakerProfession()
        {
            var createModel = new SpeakerProfessionCreateViewModel { SpeakerId = 1, ProfessionId = 1, };
            var result = await _speakerProfessionService.CreateAsync(createModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Play()
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "1.mp3");

            await _audioService.Play(path);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var id1 = int.Parse(id.Substring(id.IndexOf("#") + 1));

            var episodes = await _episodeService.GetAsync(x => x.Id == id1);

            if (episodes == null) return NotFound();

            var selectedEpisode = await _episodeService.GetAsync(x => x.Id == id1);

            if (selectedEpisode == null) return NotFound();
            IEnumerable<EpisodeViewModel> relatedEpisodes = new List<EpisodeViewModel>();

            if (selectedEpisode.Speaker is { })
                relatedEpisodes = await _episodeService.GetListAsync(x => x.Id != id1 && x.SpeakerId == selectedEpisode.Speaker.Id, include: x => x.Include(x => x.Speaker!));

            var episodeRelatedViewModel = new EpisodeRelatedViewModel
            {
                SelectedEpisode = selectedEpisode,
                RelatedEpisodes = relatedEpisodes.Take(3).ToList()
            };


            return View(episodeRelatedViewModel);



        }


    }
}
