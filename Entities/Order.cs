namespace WebApplication1.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public required DateTime OrderDate { get; set; }
        public required int UserID { get; set; }
        public required decimal TotalAmount { get; set; } 
        public required User User { get; set; }
        public  ICollection<OrderProduct>? OrderProducts { get; set; }
        public required ICollection<Ticket> Tickets { get; set; }
    }
}