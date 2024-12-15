using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;
using WebApplication1.Infrastructure.Data;

namespace WebApplication1.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();

        }
        public async Task<User?> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
