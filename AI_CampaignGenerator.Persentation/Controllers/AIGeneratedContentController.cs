using AI_CampaignGenerator.Domain.Entities.Enums;
using AI_CampaignGenerator.ServicesAbstraction;
using Microsoft.AspNetCore.Mvc;

namespace AI_CampaignGenerator.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIGeneratedContentController : ControllerBase
    {
        private readonly IAIGeneratedContentService _aiService;

        public AIGeneratedContentController(
            IAIGeneratedContentService aiService)
        {
            _aiService = aiService;
        }

        // POST: api/AIGeneratedContent?campaignId=1
        [HttpPost]
        public async Task<IActionResult> GenerateContent(
            [FromQuery] int campaignId,
            [FromQuery] string prompt,
            [FromQuery] ContentLanguage language)
        {
            var result = await _aiService.GenerateAsync(
                campaignId,
                prompt,
                language);

            return Ok(result);
        }

        // DELETE: api/AIGeneratedContent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aiService.DeleteAsync(id);
            return NoContent();
        }
    }
}