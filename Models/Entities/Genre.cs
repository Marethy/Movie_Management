namespace WebApplication1.Models.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public required string Name { get; set; }
        public required ICollection<MovieGenre> MovieGenres { get; set; }

    }
}
