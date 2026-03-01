using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared;
using AI_CampaignGenerator.Shared.DTOS.CampaignDTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Persentation.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class CampaignController : ControllerBase
        {
            private readonly ICampaignService _campaignService;

            public CampaignController(ICampaignService campaignService)
            {
                _campaignService = campaignService;
            }

            // GET: api/Campaign
            [HttpGet]
            public async Task<ActionResult<PaginatedResult<CampaignDTO>>> GetCampaigns(
                [FromQuery] CampaignQueryParams queryParams)
            {
                var result = await _campaignService.GetCampaignAsync(queryParams);
                return Ok(result);
            }

            // GET: api/Campaign/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CampaignDTO>> GetCampaignById(int id)
            {
                var campaign = await _campaignService.GetCampaignByIdAsync(id);

                if (campaign is null)
                    return NotFound();

                return Ok(campaign);
            }

            // POST: api/Campaign?userId=1
            [HttpPost]
            public async Task<ActionResult<CampaignDTO>> CreateCampaign(
                [FromQuery] int userId,
                [FromBody] CreateCampaignDTO dto)
            {
                var createdCampaign = await _campaignService.CreateCampaignAsync(userId, dto);

                return CreatedAtAction(
                    nameof(GetCampaignById),
                    new { id = createdCampaign.Id },
                    createdCampaign);
            }

            // DELETE: api/Campaign/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCampaign(int id)
            {
                var deleted = await _campaignService.DeleteCampaignAsync(id);

                if (!deleted)
                    return NotFound();

                return NoContent();
            }
        }
    }

