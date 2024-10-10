using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.SpeakerProfessionViewModels;

public class SpeakerProfessionUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public List<SelectListItem>? Speakers { get; set; }
    public int SpeakerId { get; set; }
    public List<SelectListItem>? Professions { get; set; }
    public int ProfessionId { get; set; }
}
