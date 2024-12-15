using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
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
