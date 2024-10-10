namespace Podcast.BLL.UI.Services.Contracts;

public interface IFileService
{
    (byte[] fileContent,string fileContentType, string fileName) Download(string filePath, string fileName);
    string GetFileContentType(string fileName);
}
