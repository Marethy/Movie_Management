using AutoMapper;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class SeatService:ISeatService

    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public SeatService(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<List<SeatDTO>> GetAllSeatsAsync()
        {
            var seats = await _seatRepository.GetAllSeatsAsync();
            return _mapper.Map<List<SeatDTO>>(seats);
        }

        public async Task<SeatDTO> GetSeatByIdAsync(int seatId)
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
