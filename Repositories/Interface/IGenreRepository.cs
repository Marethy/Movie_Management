using WebApplication1.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Repositories.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int genreId);
        Task AddGenreAsync(Genre genre);
        Task UpdateGenreAsync(Genre genre);
        Task DeleteGenreAsync(int genreId);

    }
}
