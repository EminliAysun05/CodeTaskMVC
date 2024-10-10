using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.SpeakerViewModels;

namespace Podcast.ADMIN.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;
        private readonly IProfessionService _professionService;

        public SpeakerController(ISpeakerService speakerService, IProfessionService professionService)
        {
            _speakerService = speakerService;
            _professionService = professionService;
        }

        public async Task<IActionResult> Index()
        {
            var speakerList = await _speakerService.GetListAsync();

            return View(speakerList.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var createModel = await _speakerService.GetSpeakerCreateViewModelAsync(new SpeakerCreateViewModel() { ImageFile = null!, Name = "" });

            return View(createModel);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpeakerCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var createModel = await _speakerService.GetSpeakerCreateViewModelAsync(model);

                return View(createModel);
            }

            var result = await _speakerService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var updateModel = await _speakerService.GetSpeakerUpdateViewModelAsync(id);

            return View(updateModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(SpeakerUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var updateModel = await _speakerService.GetSpeakerUpdateViewModelAsync(model.Id);

                return View(updateModel);
            }

            var result = await _speakerService.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
