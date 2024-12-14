using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(string userId);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(string userId);
        Task UpdateUserAsync(User user);

    }
}
