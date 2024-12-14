namespace WebApplication1.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public required  string ProductName { get; set; } 
        public required decimal Price { get; set; }
        public required string Category { get; set; }
        public required  string Image { get; set; }

    }
}
    