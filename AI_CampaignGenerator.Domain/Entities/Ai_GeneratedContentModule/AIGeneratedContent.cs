using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule
{
  public class AIGeneratedContent:BaseEntity<int>
    {
        public string? IdealHashtags { get; set; }
        public string? IdealCaption { get; set; }//will bw used as Idealcaption mapped later
        public string? Season { get; set; }
        public string? AdTone { get; set; }
        public ContentLanguage Language { get; set; }
        public string? UploadedImageURL { get; set; }
       

        public string ImagePrompt { get; set; } = default!;
        #region campiagn -Ai generated 1 to M
        //fk
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; } = default!;

        #endregion



        #region Ai-ai images 1 to M 
        public ICollection<AIGeneratedContentImages> Images { get; set; } = new List<AIGeneratedContentImages>();

        #endregion

    }
}
