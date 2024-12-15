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
    }
}
