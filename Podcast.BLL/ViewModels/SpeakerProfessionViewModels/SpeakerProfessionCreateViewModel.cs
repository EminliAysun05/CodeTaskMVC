using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.SpeakerProfessionViewModels;

public class SpeakerProfessionCreateViewModel : IViewModel
{
    public List<SelectListItem>? Speakers { get; set; }
    public int SpeakerId { get; set; }
    public List<SelectListItem>? Professions { get; set; }
    public int ProfessionId {  get; set; }
}
