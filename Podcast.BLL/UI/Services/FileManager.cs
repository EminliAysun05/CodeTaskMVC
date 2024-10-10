using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Podcast.BLL.UI.Services.Contracts;

namespace Podcast.BLL.UI.Services
{
    public class FileManager : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileManager(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public (byte[] fileContent, string fileContentType, string fileName) Download(string filePath, string fileName)
        {
            filePath = Path.Combine(filePath, fileName);
            var fileContent = File.ReadAllBytes(filePath);
            var contentType = GetFileContentType(fileName);

            return (fileContent, contentType, fileName);
        }

        public string GetFileContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(fileName, out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }
    }
}
