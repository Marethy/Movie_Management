using WebApplication1.Application.DTOs;

namespace WebApplication1.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(OrderDTO orderDto);
        Task UpdateOrderAsync(OrderDTO orderDto);
        Task DeleteOrderAsync(int orderId);
    }
}
