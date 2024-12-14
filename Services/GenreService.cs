using AutoMapper;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return _mapper.Map<List<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetGenreByIdAsync(int genreId)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(genreId);
            return _mapper.Map<GenreDTO>(genre);
        }

        public async Task AddGenreAsync(GenreDTO genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreRepository.AddGenreAsync(genre);
        }

        public async Task UpdateGenreAsync(GenreDTO genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            await _genreRepository.UpdateGenreAsync(genre);
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            await _genreRepository.DeleteGenreAsync(genreId);
        }
    }
}
