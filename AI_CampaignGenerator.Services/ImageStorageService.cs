using AI_CampaignGenerator.ServicesAbstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services
{
    public class ImageStorageService : IImageStorageService
    {
        private readonly IWebHostEnvironment _env;
        public ImageStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }
        
        public async Task<string> SaveImageAsync(IFormFile file)
        {
           if(file==null || file.Length==0)
                return string.Empty;
            //ensure webroot is not null
            var webRoot = _env.WebRootPath;
            if (string.IsNullOrEmpty(webRoot))
                throw new Exception("WebRootPath is not configured.");
            var folderPath = Path.Combine(webRoot, "images", "ai-generated");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var fileName=$"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath=Path.Combine(folderPath, fileName);
            using(var stream=new FileStream(filePath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/images/ai-generated/{fileName}";
        }
        public Task DeleteImageAsync(string imageUrl)
        {
            if(string.IsNullOrEmpty(imageUrl)) 
                return Task.CompletedTask;
            var fileName=Path.GetFileName(imageUrl);
            var filePath = Path.Combine(
                _env.WebRootPath,
                "images",
                "ai-generated",
                fileName
                );
            if(File.Exists(filePath))
                File.Delete(filePath);
            return Task.CompletedTask;
        }

        public async Task<string> SaveImageAsync(byte[] imageBytes)
        {
            
           var webRoot = _env.WebRootPath;
            var folderPath = Path.Combine(webRoot, "images", "ai-generated");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var fileName = $"{Guid.NewGuid()}.png";
            var filePath=Path.Combine(folderPath, fileName);
            await File.WriteAllBytesAsync(filePath, imageBytes);
            return $"/images/ai-generated/{fileName}";

        }
    }
}
