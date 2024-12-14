using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public required DateTime OrderDate { get; set; }
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public required User User { get; set; }

        public required decimal TotalAmount { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public required ICollection<Ticket> Tickets { get; set; }
    }
}
