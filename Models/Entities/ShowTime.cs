namespace WebApplication1.Models.Entities
{
    public class ShowTime
    {
        public int ShowTimeId { get; set; }
        public required int MovieID { get; set; }
        public required int RoomID { get; set; }
        public required DateTime Time { get; set; }

        public required Movie Movie { get; set; }
        public required Room Room { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}