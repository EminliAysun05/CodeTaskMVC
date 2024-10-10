using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Podcast.BLL.Services.Contracts;

namespace Podcast.BLL.Services
{
    public class CloudinaryManager : ICloudinaryService
    {
        private readonly IConfiguration _configuration;

        public CloudinaryManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> AudioCreateAsync(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            string fileName = string.Concat(Guid.NewGuid(), file.FileName.Substring(file.FileName.LastIndexOf('.')));
            var myAccount = new Account
            {
                ApiKey = _configuration["CloudinarySettings:APIKey"],
                ApiSecret = _configuration["CloudinarySettings:APISecret"],
                Cloud = _configuration["CloudinarySettings:CloudName"]
            };

            Cloudinary _cloudinary = new Cloudinary(myAccount);
            _cloudinary.Api.Secure = true;
            var uploadResult = new RawUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new RawUploadParams
                {
                    File = new FileDescription(fileName, stream),
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            string url = uploadResult.SecureUrl.ToString();

            return url;
        }

        public async Task<string> ImageCreateAsync(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));

            string fileName = string.Concat(Guid.NewGuid(), file.FileName.Substring(file.FileName.LastIndexOf('.')));
            var myAccount = new Account
            {
                ApiKey = _configuration["CloudinarySettings:APIKey"],
                ApiSecret = _configuration["CloudinarySettings:APISecret"],
                Cloud = _configuration["CloudinarySettings:CloudName"] 
            };

            Cloudinary _cloudinary = new Cloudinary(myAccount);
            _cloudinary.Api.Secure = true;
            var uploadResult = new ImageUploadResult();
          
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, stream),
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            string url = uploadResult.SecureUrl.ToString();

            return url;
        }
    }
}
