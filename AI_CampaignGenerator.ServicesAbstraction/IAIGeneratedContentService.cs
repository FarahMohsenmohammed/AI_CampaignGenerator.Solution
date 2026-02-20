using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using AI_CampaignGenerator.Domain.Entities.Enums;

namespace AI_CampaignGenerator.ServicesAbstraction
{
    public interface IAIGeneratedContentService
    {
        Task<AIGeneratedContent> GenerateAsync(int campaignId,string prompt, ContentLanguage language);
        Task DeleteAsync(int aiGeneratedContentId);
    }
}
