using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : BaseController
    {
        private readonly IOrderService _orderService = orderService;
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return HandleResult(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return HandleResult(order);
        }
        [HttpPost]
        public  async Task<IActionResult> AddOrderAsync([FromBody] OrderDTO orderDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _orderService.AddOrderAsync(orderDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] OrderDTO orderDto)
        {
            if (!IsValidId(id) ||id!=orderDto.OrderID) return BadRequest(ModelState);
            await _orderService.UpdateOrderAsync(orderDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
