using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Podcast.BLL.ViewModels.SpeakerViewModels;

public class SpeakerUpdateViewModel : IViewModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IFormFile? ImageFile { get; set; }
    //public string? ImageUrl { get; set; }
    public List<SelectListItem>? OldProfessions { get; set; }
    public int[]? OldProfessionIds { get; set; }

    public List<SelectListItem>? NewProfessions { get; set; }
    public int[]? NewProfessionIds { get; set; }
}
