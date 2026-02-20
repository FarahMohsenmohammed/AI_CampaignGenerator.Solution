using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Contracts
{
    public interface IDataInitializer
    {
        Task InitializeAsync();
    }
}
