using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories.Interface
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int roomId); 
        Task AddRoomAsync (Room room);  
        Task DeleteRoomAsync (int roomId);  
        Task UpdateRoomAsyc (Room room);    

    }
}
