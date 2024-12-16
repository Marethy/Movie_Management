using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllRoomsAsync();
        Task<RoomDTO?> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(RoomDTO roomDto);
        Task UpdateRoomAsync(RoomDTO roomDto);
        Task DeleteRoomAsync(int roomId);
    }
}
