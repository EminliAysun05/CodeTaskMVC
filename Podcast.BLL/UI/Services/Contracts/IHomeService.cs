using Podcast.BLL.UI.ViewModels;

namespace Podcast.BLL.UI.Services.Contracts;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModel();
    Task<(byte[] fileContent, string fileContentType, string fileName)> Download(int id);
}
