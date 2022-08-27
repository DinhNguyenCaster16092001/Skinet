using Core.Entities;
using Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly SkinetDbContext _skinetDbContext;

        public ProductsController(SkinetDbContext skinetDbContext)
        {
            _skinetDbContext = skinetDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await _skinetDbContext.Products.ToListAsync();
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> GetSigleProduct(int id)
        {
            try
            {
                var product = await _skinetDbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
