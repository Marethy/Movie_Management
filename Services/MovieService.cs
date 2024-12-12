//using AutoMapper;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WebApplication1.Models.DTOs;
//using WebApplication1.Models.Entities;

//public class MovieService : IMovieService
//{
//    private readonly IMovieRepository _movieRepository;
//    private readonly IMapper _mapper;

//    public MovieService(IMovieRepository movieRepository, IMapper mapper)
//    {
//        _movieRepository = movieRepository;
//        _mapper = mapper;
//    }

//    public async Task<List<MovieDTO>> GetAllMoviesAsync()
//    {
//        var movies = await _movieRepository.GetAllAsync();
//        return _mapper.Map<List<MovieDTO>>(movies);
//    }

//    public async Task<MovieDTO> GetMovieByIdAsync(int movieId)
//    {
//        var movie = await _movieRepository.GetByIdAsync(movieId);
//        return _mapper.Map<MovieDTO>(movie);
//    }

//    public async Task AddMovieAsync(MovieDTO movieDto)
//    {
//        var movie = _mapper.Map<Movie>(movieDto);
//        await _movieRepository.AddMovieAsync(movie);
//    }

//    public async Task UpdateMovieAsync(MovieDTO movieDto)
//    {
//        var movie = _mapper.Map<Movie>(movieDto);
//        await _movieRepository.UpdateMovieAsync(movie);
//    }

//    public async Task DeleteMovieAsync(int movieId)
//    {
//        await _movieRepository.DeleteMovieAsync(movieId);
//    }
//}
