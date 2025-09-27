using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _uow.Products.GetAllAsync();
            var result = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.PictureUrl,
                p.Price,
                BrandName = p.Brand != null ? p.Brand.Name : string.Empty,
                TypeName = p.Type != null ? p.Type.Name : string.Empty
            });

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _uow.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var result = new
            {
                product.Id,
                product.Name,
                product.Description,
                product.PictureUrl,
                product.Price,
                BrandName = product.Brand != null ? product.Brand.Name : string.Empty,
                TypeName = product.Type != null ? product.Type.Name : string.Empty
            };

            return Ok(result);
        }

    }
}
