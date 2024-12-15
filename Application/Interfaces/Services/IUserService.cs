using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(string userId);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(string userId);
    }
}