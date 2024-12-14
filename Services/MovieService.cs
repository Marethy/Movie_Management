using AutoMapper;
using System.Threading.Tasks;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories.Interface;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<List<MovieDTO>> GetAllMoviesAsync()
    {
        var movies = await _movieRepository.GetAllMoviesAsync();
        return _mapper.Map<List<MovieDTO>>(movies);
    }

    public async Task<MovieDTO> GetMovieByIdAsync(int movieId)
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
