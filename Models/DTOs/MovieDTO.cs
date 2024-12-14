namespace WebApplication1.Models.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
