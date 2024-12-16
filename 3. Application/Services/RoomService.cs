using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class RoomService(IRoomRepository roomRepository, IMapper mapper) : IRoomService
    {
        private readonly IRoomRepository _roomRepository = roomRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<RoomDTO>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        public async Task<RoomDTO?> GetRoomByIdAsync(int roomId)
        {
            var room = await _roomRepository.GetRoomByIdAsync(roomId);
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task AddRoomAsync(RoomDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task UpdateRoomAsync(RoomDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _roomRepository.UpdateRoomAsyc(room);
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            await _roomRepository.DeleteRoomAsync(roomId);
        }
    }
}
