using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.Services.Contracts
{
    public interface IAudioService
    {
        Task Play(string filePath);
        Task Pause();
        Task Resume();
        Task Stop();
    }
}
