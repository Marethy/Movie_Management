using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication1.Application.DTOs;
using WebApplication1.Application.Interfaces.Services;

namespace WebApplication1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : BaseController
    {
        private readonly IProductService _ProductService = productService;
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _ProductService.GetAllProductsAsync();
            return HandleResult(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _ProductService.GetProductByIdAsync(id);
            return HandleResult(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _ProductService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductByIdAsync), new { id = productDto.ProductID }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductDTO productDto)
        {
            if (!IsValidId(id) || id != productDto.ProductID) return BadRequest(ModelState);
            await _ProductService.UpdateProductAsync(productDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if (!IsValidId(id)) return BadRequest(ModelState);
            await _ProductService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
