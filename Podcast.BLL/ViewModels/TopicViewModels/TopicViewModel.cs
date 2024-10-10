using Microsoft.AspNetCore.Http;
using Podcast.BLL.ViewModels.EpisodeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.ViewModels.TopicViewModels
{
    public class TopicViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CoverUrl { get; set; }
        public List<EpisodeViewModel>? Episodes {  get; set; }
    }

    public class TopicCreateViewModel : IViewModel
    {
        public required string Name { get; set; }
        public required IFormFile CoverFile {  get; set; }
        public string? CoverUrl { get; set; }
    }

    public class TopicUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IFormFile? CoverFile { get; set; }
        public string? CoverUrl { get; set; }
    }
}
