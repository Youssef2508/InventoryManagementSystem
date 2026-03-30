using Microsoft.AspNetCore.Mvc;
using Project_2.Services;
using Project_2.DTOs.CategoryDTOs;

namespace Project_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // 🟢 GET
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryFilterDto filter)
        {
            var result = await _categoryService.GetAllAsync(filter);
            return Ok(result);
        }

        // 🟢 GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // 🟢 CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            var result = await _categoryService.CreateAsync(dto);

            if (result == null)
                return BadRequest("Category name must be unique");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // 🟢 UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto dto)
        {
            var updated = await _categoryService.UpdateAsync(dto);

            if (!updated)
                return BadRequest("Category not found or name already exists");

            return NoContent();
        }

        // 🟢 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoryService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}