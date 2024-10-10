using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.SpeakerViewModels;

public class SpeakerCreateViewModel : IViewModel
{
    public required string Name { get; set; }
    public required IFormFile ImageFile { get; set; }
    public string? ImageUrl { get; set; }
    public List<SelectListItem>? Professions { get; set; }
    public int[]? ProfessionIds { get; set; }
}
