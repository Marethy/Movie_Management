using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.Data;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories
{
    public class RoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();

        }
        public async Task<Room?> GetRoomByIdAsync(int roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r=>r.RoomID == roomId);
        }
        public  async Task AddRoomAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRoomAsync(int roomId)
        {
            var room = await GetRoomByIdAsync(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateRoomAsync(Room room)
        {
            _context.Rooms.Update(room); 
            await _context.SaveChangesAsync();
        }
    }
}
