using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(User user);

    }
}
