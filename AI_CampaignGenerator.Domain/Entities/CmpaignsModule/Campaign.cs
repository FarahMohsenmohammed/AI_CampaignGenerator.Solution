using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using AI_CampaignGenerator.Domain.Entities.ProductModule;
using AI_CampaignGenerator.Domain.Entities.UserModule;
using AI_CampaignGenerator.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AI_CampaignGenerator.Domain.Entities.CmpaignsModule
{
    public class Campaign : BaseEntity<int>
    {
        // GeneratdAt==date of base
        public string Campaign_Name { get; set; } = default!;
        public DateTime? EndDate { get; set; }
        public string? Platform { get; set; }
        public string CampaignGoal { get; set; } = default!;
        //public CampaignStatus Status { get; set; }
        public CampaignStatus Status
        {
            get
            {
                var today = DateTime.UtcNow;

                if (today < CreatedAt)
                    return CampaignStatus.Pending;

                if (EndDate == null || today <= EndDate)
                    return CampaignStatus.Active;

                return CampaignStatus.Ended;
            }
            set
            {

            }
        }
        //public CampaignStatus Status =>
        //    DateTime.Today < CreatedAt ? CampaignStatus.Pending :
        //    EndDate == null || DateTime.Today <= EndDate ? CampaignStatus.Active :
        //    CampaignStatus.Ended;


        #region campaign - AI generated content 1 to M

        public ICollection<AIGeneratedContent> AIContents { get; set; } = new List<AIGeneratedContent>();

        #endregion
        //Campaigns  mto 1 with prod
        //fk
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        //campaign with user
        public int UserId { get; set; }
        public User User { get; set; } = default!;



    }
}

