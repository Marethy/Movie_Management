using AutoMapper;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;
        private readonly IMapper _mapper;

        public TheaterService(ITheaterRepository theaterRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _mapper = mapper;
        }

        public async Task<List<TheaterDTO>> GetAllTheatersAsync()
        {
            var theaters = await _theaterRepository.GetAllTheatersAsync();
            return _mapper.Map<List<TheaterDTO>>(theaters);
        }

        public async Task<TheaterDTO> GetTheaterByIdAsync(int theaterId)
        {
            var theater = await _theaterRepository.GetTheaterByIdAsync(theaterId);
            return _mapper.Map<TheaterDTO>(theater);
        }

        public async Task AddTheaterAsync(TheaterDTO theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);
            await _theaterRepository.AddTheaterAsync(theater);
        }

        public async Task UpdateTheaterAsync(TheaterDTO theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);
            await _theaterRepository.UpdateTheaterAsync(theater);
        }

        public async Task DeleteTheaterAsync(int theaterId)
        {
            await _theaterRepository.DeleteTheaterAsync(theaterId);
        }
    }
}
