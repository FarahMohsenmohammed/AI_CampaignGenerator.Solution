using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.Enums;
using AI_CampaignGenerator.Services.Specifications;
using AI_CampaignGenerator.ServicesAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services
{

    public class AIGeneratedContentService
    : IAIGeneratedContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorageService _imageStorage;
        private readonly IHttpClientFactory _httpClientFactory;

        public AIGeneratedContentService(
            IUnitOfWork unitOfWork,
            IImageStorageService imageStorage,
            IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _imageStorage = imageStorage;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AIGeneratedContent> GenerateAsync(
            int campaignId,
            string prompt,
            ContentLanguage language)
        {
            // 1️⃣ تأكد إن الحملة موجودة
            var campaign = await _unitOfWork.GetRepository<Campaign,int>().GetByIdAsync(campaignId);

            if (campaign == null)
                throw new Exception("Campaign not found");

            // 2️⃣ Generate Text
            var generatedCaption =
                await GenerateTextAsync(prompt, language);

            // 3️⃣ Generate 3 Images
            var generatedImages =
                await GenerateImagesAsync(prompt);

            var imageEntities =
                new List<AIGeneratedContentImages>();

            // wwwroot  Save Images
            foreach (var imageBytes in generatedImages)
            {
                var url = await _imageStorage
                    .SaveImageAsync(imageBytes,"ai-generated");

                imageEntities.Add(
                    new AIGeneratedContentImages
                    {
                        GeneratedImageURL = url
                    });
            }

            // 5️⃣ Build Entity
            var content = new AIGeneratedContent
            {
                CampaignId = campaignId,
                Language = language,
                IdealCaption = generatedCaption,
                ImagePrompt = prompt,
                Images = imageEntities
            };

            // 6️⃣ Save in DB
            await _unitOfWork
                .GetRepository<AIGeneratedContent, int>()
                .AddAsync(content);

            await _unitOfWork.SaveChangesAsync();

            return content;
        }

        public async Task DeleteAsync(int aiGeneratedContentId)
        {
            var spec = new AIGeneratedContentWithImagesSpecification(aiGeneratedContentId);

            var contents = await _unitOfWork
                .GetRepository<AIGeneratedContent, int>()
                .GetAllAsync(spec);
            var content=contents.FirstOrDefault();

            if (content == null)
                throw new Exception("AI Generated Content not found");

            // Delete images from server
            foreach (var image in content.Images)
            {
                await _imageStorage
                    .DeleteImageAsync(image.GeneratedImageURL,"ai-generated");
            }

            // Delete from DB
            _unitOfWork
                .GetRepository<AIGeneratedContent, int>()
                .Remove(content);

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<string> GenerateTextAsync(
            string prompt,
            ContentLanguage language)
        {
            var client = _httpClientFactory.CreateClient();

            if (language == ContentLanguage.English)
            {
                // هنا هتنادي English Model Endpoint
                return $"English generated content for {prompt}";
            }
            else
            {
                // هنا هتنادي Arabic Model Endpoint
                return $"محتوى عربي تم إنشاؤه لـ {prompt}";
            }
        }

        private async Task<List<byte[]>> GenerateImagesAsync(
            string prompt)
        {
            var images = new List<byte[]>();

            for (int i = 0; i < 3; i++)
            {
                // مؤقت لحد ما image API يتربط
                images.Add(File.ReadAllBytes("DummyImage.png"));
            }

            return images;
        }
    }

}
