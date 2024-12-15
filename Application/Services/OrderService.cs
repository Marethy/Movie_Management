using AutoMapper;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;
using WebApplication1.Domain.Entities;
using WebApplication1.Domain.Interfaces.Repositories;

namespace WebApplication1.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task AddOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }
    }
}
