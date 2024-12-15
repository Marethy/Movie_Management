namespace WebApplication1.Domain.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public required int ShowTimeID { get; set; }
        public required int SeatID { get; set; }
        public required int OrderID { get; set; }
        public required decimal Price { get; set; }
        public required ShowTime ShowTime { get; set; }
        public required Seat Seat { get; set; }
        public required Order Order { get; set; }
    }
}