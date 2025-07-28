using System.Text.Json;
using AdventureWorks.Domain.Entities;
using AdventureWorks.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace AdventureWorks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AdventureWorksDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly IDistributedCache _distributedCache;

        public ProductsController(AdventureWorksDbContext context, IMemoryCache cache, IDistributedCache distributedCache)
        {
            _context = context;
            _cache = cache;
            _distributedCache = distributedCache;
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

        [HttpGet("cached-products")]
        public async Task<IActionResult> GetCachedProducts()
        {
            var cacheKey = "products_10";
            if (_cache.TryGetValue(cacheKey, out List<Product> cachedProducts))
            {
                return Ok(new { source = "cache", products = cachedProducts });
            }

            var products = await _context.Products
            .Take(10).AsNoTracking()
            .ToListAsync();

            _cache.Set(cacheKey, products, TimeSpan.FromMinutes(5));
            return Ok(new { source = "db", products });
        }

        [HttpGet("redis-products")]
        public async Task<IActionResult> GetRedisCachedProducts()
        {
            var cacheKey = "products_redis";
            var cachedData = await _distributedCache.GetStringAsync(cacheKey);


            if (!string.IsNullOrEmpty(cachedData))
            {
                var products = JsonSerializer.Deserialize<List<Product>>(cachedData);
                return Ok(new { source = "redis", products });
            }

            var data = await _context.Products
                .Take(10)
                .AsNoTracking()
                .ToListAsync();

            var json = JsonSerializer.Serialize(data);
            await _distributedCache.SetStringAsync(cacheKey, json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(0.1)
            });

            return Ok(new { source = "db", products = data });
        }
            
    }
}