using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interface
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllRoomsAsync();
        Task<RoomDTO> GetRoomByIdAsync(int roomId);
        Task AddRoomAsync(RoomDTO roomDto);
        Task UpdateRoomAsync(RoomDTO roomDto);
        Task DeleteRoomAsync(int roomId);
    }
}
