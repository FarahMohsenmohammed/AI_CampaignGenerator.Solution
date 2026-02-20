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
        Task<string>SaveImageAsync(IFormFile file);
        Task<string>SaveImageAsync(byte[]  imageBytes);
        Task DeleteImageAsync(string imageUrl);
    }
}
