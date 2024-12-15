namespace WebApplication1.Application.DTOs
{
    public class TicketDTO
    {
        public required int TicketID { get; set; }
        public required int ShowTimeID { get; set; }
        public required int SeatID { get; set; }
        public required int OrderID { get; set; }
        public required decimal Price { get; set; }
        public required ShowTimeDTO ShowTime { get; set; }
        public required SeatDTO Seat { get; set; }
        public required OrderDTO Order { get; set; }
    }
}
