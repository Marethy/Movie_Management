using WebApplication1.Domain.Entities;

namespace WebApplication1.Application.DTOs
{
    public class OrderProductDTO
    {
        public int OrderID { get; set; }
        public required int ProductID { get; set; }
        public required int Quantity { get; set; }

        public required OrderDTO Order { get; set; }
        public required ProductDTO Product { get; set; }
    }
}
