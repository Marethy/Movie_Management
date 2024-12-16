using AutoMapper;
using System.Threading.Tasks;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class MovieService(IMovieRepository movieRepository, IMapper mapper) : IMovieService
    {
        private readonly IMovieRepository _movieRepository = movieRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return _mapper.Map<List<MovieDTO>>(movies);
        }

        public async Task<MovieDTO?> GetMovieByIdAsync(int movieId)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(movieId);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task AddMovieAsync(MovieDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.AddMovieAsync(movie);
        }

        public async Task UpdateMovieAsync(MovieDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.UpdateMovieAsync(movie);
        }

        public async Task DeleteMovieAsync(int movieId)
        {
            await _movieRepository.DeleteMovieAsync(movieId);
        }
    }

}