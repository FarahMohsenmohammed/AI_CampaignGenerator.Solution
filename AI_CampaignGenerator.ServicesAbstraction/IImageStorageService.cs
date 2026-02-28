using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.ServicesAbstraction
{
    public interface IImageStorageService
    {
        // Save user uploaded image (Product Images)
        Task<string> SaveImageAsync(IFormFile file, string folderName);

        // Save AI generated image (byte array)
        Task<string> SaveImageAsync(byte[] imageBytes, string folderName);

        // Delete image
        Task DeleteImageAsync(string imageUrl, string folderName);
    }
}
