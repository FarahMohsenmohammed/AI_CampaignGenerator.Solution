using AI_CampaignGenerator.Shared.DTOS.UserDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.ServicesAbstraction
{
   public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDetailsDTO?>GetUserByIdAsync(int id);
        Task<UserDetailsDTO?> CreateUserAsync(CreateUserDTO dto);
        Task<UserDetailsDTO?> UpdateUserAsync(int id, CreateUserDTO dto);
        Task<bool> DeleteUserAsync(int id);

    }
}
