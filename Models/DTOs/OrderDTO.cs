using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public required  string UserId { get; set; }
        public decimal TotalAmount { get; set; }



        // Thông tin về sản phẩm trong đơn hàng
        public List<OrderProductDTO>? OrderProducts { get; set; }

        // Thông tin vé (Tickets)
        public required List<TicketDTO> Tickets { get; set; }
    }
}
