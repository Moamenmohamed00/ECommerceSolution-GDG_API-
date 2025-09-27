using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _uow;
        public BrandController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            return Ok(await _uow.Brands.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            var brand = await _uow.Brands.GetByIdAsync(id);
            if (brand == null) return NotFound();
            return Ok(brand);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByBrand(int id)
        {
            var products = await _uow.Products.FindAsync(p => p.BrandId == id);
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult> CreateBrand([FromBody] Brand brand)
        {
            if (brand == null || string.IsNullOrWhiteSpace(brand.Name))
            {
                return BadRequest("Brand name is required.");
            }
            await _uow.Brands.AddAsync(brand);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBrand(int id, [FromBody] Brand brand)
        {
            if (brand == null || id != brand.Id || string.IsNullOrWhiteSpace(brand.Name))
            {
                return BadRequest("Invalid brand data.");
            }
            var existingBrand = await _uow.Brands.GetByIdAsync(id);
            if (existingBrand == null)
            {
                return NotFound();
            }
            existingBrand.Name = brand.Name;
            _uow.Brands.Update(existingBrand);
            await _uow.CompleteAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var brand = await _uow.Brands.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            _uow.Brands.Delete(brand);
            await _uow.CompleteAsync();
            return NoContent();
        }
    }
}
