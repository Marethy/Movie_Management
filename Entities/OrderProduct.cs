namespace WebApplication1.Entities
{
    public class OrderProduct
    {
        public int OrderID { get; set; }
        public required int ProductID { get; set; }
        public required int Quantity { get; set; }

        public required Order Order { get; set; }
        public required Product Product { get; set; }
    }
}