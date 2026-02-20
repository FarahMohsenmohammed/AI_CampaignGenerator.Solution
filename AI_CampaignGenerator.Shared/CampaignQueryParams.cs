using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared
{
    public class CampaignQueryParams
    {
        public int? UserId { get; set; }
        public CampaignSortingOptions Sort { get; set; } = CampaignSortingOptions.CreatedAtDesc;
        private int _pageIndex = 1;
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value <= 0 ? 1 : value;
        }
        private const int DefaultPageSize=5 ;
        private const int MaxPageSize=10 ;
        
        public int _pageSize=DefaultPageSize;
        public int PageSize
        {
            get=>_pageSize;
            set
            {
                if (value <= 0)
                    _pageSize = DefaultPageSize;
                else if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else 
                    _pageSize = value;
            }
        }
    }
}
