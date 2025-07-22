using AdventureWorks.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AdventureWorksDbContext _context;
        public ProductsController(AdventureWorksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products
            .AsNoTracking()
            .Take(50)
            .ToListAsync();
            return Ok(products);
        }

        [HttpGet("lazy")]
        public async Task<IActionResult> GetLazy()
        {
            var products = await _context.Products
            .Take(10)
            .ToListAsync();

            var result = products.Select(p => new
            {
                p.Name,
                Subcategory = p.ProductSubcategory?.Name
            });
            return Ok(result);
        }

        [HttpGet("eager")]
        public async Task<IActionResult> GetEager()
        {
            var products = await _context.Products
            .Include(p => p.ProductSubcategory)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                Subcategory = p.ProductSubcategory != null ? p.ProductSubcategory.Name : null,
            }).ToListAsync();

            return Ok(products);
        }
    }
}