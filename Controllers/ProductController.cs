using Microsoft.AspNetCore.Mvc;
using Project_2.Services;
using Project_2.DTOs.ProductDTOs;

namespace Project_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // 🟢 GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilterDto filter)
        {
            var result = await _productService.GetAllAsync(filter); 
            return Ok(result); 
        }

        // 🟢 GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // 🟢 POST: api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // 🟢 PUT: api/products
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto dto)
        {
            var updated = await _productService.UpdateAsync(dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // 🟢 DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
