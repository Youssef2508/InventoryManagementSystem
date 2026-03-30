using Microsoft.AspNetCore.Mvc;
using Project_2.DTOs.SupplierDTOs;
using Project_2.Services;

namespace Project_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // 🟢 GET
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SupplierFilterDto filter)
        {
            var result = await _supplierService.GetAllAsync(filter);
            return Ok(result);
        }

        // 🟢 GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);

            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        // 🟢 CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDto dto)
        {
            var result = await _supplierService.CreateAsync(dto);

            if (result == null)
                return BadRequest("Supplier email already exists");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // 🟢 UPDATE
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDto dto)
        {
            var updated = await _supplierService.UpdateAsync(dto);

            if (!updated)
                return BadRequest("Supplier not found or email already exists");

            return NoContent();
        }

        // 🟢 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _supplierService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}