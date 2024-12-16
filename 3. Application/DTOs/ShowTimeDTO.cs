namespace WebApplication1.Application.DTOs
{
    public class ShowTimeDTO
    {
        public int ShowTimeID { get; set; }
        public required int MovieID { get; set; }
        public required int RoomID { get; set; }
        public required DateTime Time { get; set; }

        public string? MovieTitle { get; set; }

        public ICollection<TicketDTO>? Tickets { get; set; }
    }
}