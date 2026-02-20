using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Domain.Entities.UserModule;
using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared.DTOS.UserDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users=await _unitOfWork.GetRepository<User,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);

        }
        public async Task<UserDetailsDTO?> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.GetRepository<User, int>().GetByIdAsync(id);
            if(user is null)return null;
            return _mapper.Map<UserDetailsDTO>(user);
        }

        public async Task<UserDetailsDTO?> CreateUserAsync(CreateUserDTO dto)
        {
           var user=_mapper.Map<User>(dto);
            await _unitOfWork.GetRepository<User,int>().AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDetailsDTO>(user);
        }

        
        

        public async Task<UserDetailsDTO?> UpdateUserAsync(int id, CreateUserDTO dto)
        {
            var repo = _unitOfWork.GetRepository<User, int>();
            var user=await repo.GetByIdAsync(id);
            if(user is null)return null;
            user.FirstName= dto.FirstName;
            user.LastName= dto.LastName;
            user.Email= dto.Email;
            repo.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDetailsDTO>(user);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var repo=_unitOfWork.GetRepository<User, int>();
            var user= await repo.GetByIdAsync(id);
            if(user is null)return false;
            repo.Remove(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
