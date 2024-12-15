using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.DTOs
{
    public class MovieGenreDTO
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }

        public required MovieDTO Movie { get; set; }
        public required GenreDTO Genre { get; set; }
    }
}
