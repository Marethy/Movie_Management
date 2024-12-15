using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class GenreService(IGenreRepository genreRepository, IMapper mapper) : IGenreService
    {
        private readonly IGenreRepository _genreRepository = genreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GenreDTO>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            return _mapper.Map<List<GenreDTO>>(genres);
        }

        public async Task<GenreDTO?> GetGenreByIdAsync(int genreId)
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
