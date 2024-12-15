using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SQLitePCL;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class MovieGenreService(IMovieGenreRepository movieGenreRepository, IMapper mapper) : IMovieGenreService
    {
        private readonly IMovieGenreRepository _movieGenreRepository = movieGenreRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MovieGenreDTO>> GetAllMovieGenresAsync()
        {
            var movieGenres = await _movieGenreRepository.GetAllMovieGenresAsync();
            return _mapper.Map<List<MovieGenreDTO>>(movieGenres);
        }

        public async Task<MovieGenreDTO?> GetMovieGenreByIdAsync(int movieId, int genreId)
        {
            var movieGenre = await _movieGenreRepository.GetMovieGenreByIdAsync(movieId, genreId);
            return _mapper.Map<MovieGenreDTO>(movieGenre);
        }

        public async Task AddMovieGenreAsync(MovieGenreDTO movieGenreDto)
        {
            var movieGenre = _mapper.Map<MovieGenre>(movieGenreDto);
            await _movieGenreRepository.AddMovieGenreAsync(movieGenre);
        }
        public async Task UpdateMovieGenreAsync(MovieGenreDTO movieGenreDto)
        {
            var moviveGenre = _mapper.Map<MovieGenre>(movieGenreDto);
            await _movieGenreRepository.UpdateMovieGenreAsync(moviveGenre);
        }
        public async Task DeleteMovieGenreAsync(int movieId, int genreId)
        {
            await _movieGenreRepository.DeleteMovieGenreAsync(movieId, genreId);
        }
    }
}
