using System;
using System.Collections.Generic;

namespace WebApplication1.Application.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public required string UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderProductDTO>? OrderProducts { get; set; }

        public required List<TicketDTO> Tickets { get; set; }
    }
}
