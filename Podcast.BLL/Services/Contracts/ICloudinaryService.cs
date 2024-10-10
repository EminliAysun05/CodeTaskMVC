using Microsoft.AspNetCore.Http;

namespace Podcast.BLL.Services.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> ImageCreateAsync(IFormFile file);
        Task<string> AudioCreateAsync(IFormFile file);
    }
}
