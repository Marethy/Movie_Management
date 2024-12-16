using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class SeatService(ISeatRepository seatRepository, IMapper mapper) : ISeatService

    {
        private readonly ISeatRepository _seatRepository = seatRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<SeatDTO>> GetAllSeatsAsync()
        {
            var seats = await _seatRepository.GetAllSeatsAsync();
            return _mapper.Map<List<SeatDTO>>(seats);
        }

        public async Task<SeatDTO?> GetSeatByIdAsync(int seatId)
        {
            var seat = await _seatRepository.GetSeatByIdAsync(seatId);
            return _mapper.Map<SeatDTO>(seat);
        }

        public async Task AddSeatAsync(SeatDTO seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            await _seatRepository.AddSeatAsync(seat);
        }

        public async Task UpdateSeatAsync(SeatDTO seatDto)
        {
            var seat = _mapper.Map<Seat>(seatDto);
            await _seatRepository.UpdateSeatAsync(seat);
        }

        public async Task DeleteSeatAsync(int seatId)
        {
            await _seatRepository.DeleteSeatAsync(seatId);
        }
        public async Task GenerateSeatsForRoomAsync(int roomId, int capacity)
        {
            var seats = new List<Seat>();
            char rowLabel = 'A'; // Ký hiệu hàng bắt đầu từ 'A'

            for (int i = 0; i < capacity; i++)
            {
                // Tạo số ghế dạng A1, A2, ..., B1, B2, ...
                string seatNumber = $"{rowLabel}{(i % 10) + 1}";

                seats.Add(new Seat
                {
                    RoomID = roomId,
                    SeatNumber = seatNumber,
                    Status = Utils.Enums.SeatStatus.Available // Mặc định là Available
                });

                // Khi ghế thứ 10 hoàn thành, chuyển sang hàng tiếp theo
                if ((i + 1) % 10 == 0) rowLabel++;
            }

            // Lưu vào cơ sở dữ liệu
            await _seatRepository.AddSeatsAsync(seats);
        }
    }
}
