using NetCoreAudio;
using NetCoreAudio.Interfaces;
using Podcast.BLL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcast.BLL.Services
{
    public class AudioManager : IAudioService
    {
        private readonly IPlayer _player;

        public AudioManager(IPlayer player)
        {
            _player = player;
        }

        public async Task Play(string filePath)
        {
           await _player.Play(filePath);
        }

        public async Task Pause()
        {
            await _player.Pause();
        }

        public async Task Resume()
        {
            await _player.Resume();
        }

        public async Task Stop()
        {
           await _player.Stop();    
        }
    }
}
