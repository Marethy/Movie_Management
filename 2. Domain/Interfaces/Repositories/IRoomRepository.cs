using WebApplication1.Domain.Entities;

namespace WebApplication1.Domain.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(Room room);
        Task DeleteRoomAsync(int roomId);
        Task UpdateRoomAsyc(Room room);

    }
}
