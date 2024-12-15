using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetUserByIdAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(string userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
