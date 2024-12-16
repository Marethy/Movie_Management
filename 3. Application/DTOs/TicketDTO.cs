namespace WebApplication1.Application.DTOs
{
    public class TicketDTO
    {
        public  int TicketID { get; set; }
        public required int ShowTimeID { get; set; }
        public required int SeatID { get; set; }
        public required int OrderID { get; set; }
        public required decimal Price { get; set; }
        public  ShowTimeDTO? ShowTime { get; set; }
        public  SeatDTO? Seat { get; set; }
        public  OrderDTO? Order { get; set; }
    }
}
