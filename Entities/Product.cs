namespace WebApplication1.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public required  string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required string Category { get; set; }
        public required string Image { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
