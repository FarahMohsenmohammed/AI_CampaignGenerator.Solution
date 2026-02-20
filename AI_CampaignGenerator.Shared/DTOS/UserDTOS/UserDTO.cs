using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared.DTOS.UserDTOS
{
   public class UserDTO
    {
        public int Id {  get; set; }
        public string FullName { get; set; }= default!;
        public string Email { get; set; } = default!;
    }
}
