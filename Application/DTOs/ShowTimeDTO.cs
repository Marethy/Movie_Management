namespace WebApplication1.Application.DTOs
{
    public class ShowTimeDTO
    {
        public int ShowTimeID { get; set; }
        public int MovieID { get; set; }
        public int RoomID { get; set; }
        public DateTime Time { get; set; }

        public string MovieTitle { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;

        public ICollection<TicketDTO>? Tickets { get; set; }
    }
}