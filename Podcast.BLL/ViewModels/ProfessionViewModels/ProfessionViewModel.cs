using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.ViewModels.ProfessionViewModels
{
    public class ProfessionViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ProfessionCreateViewModel : IViewModel
    {
        public string? Name { get; set; }
    }

    public class ProfessionUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }


}
