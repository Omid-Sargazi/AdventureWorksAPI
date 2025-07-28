using AdventureWorks.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorksDbContext _context;
        public ProductRepository(AdventureWorksDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.Product product, CancellationToken cancellationToken)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Domain.Entities.Product>> FilterProductsAsync(string? name, decimal? minPrice, decimal? maxPrice, int? subcategoryId, CancellationToken token)
        {
            var query = _context.Products.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));
            if (minPrice.HasValue)
                query = query.Where(p => p.ListPrice >= minPrice);
            if (maxPrice.HasValue)
                query = query.Where(p => p.ListPrice <= maxPrice);
            if (subcategoryId.HasValue)
                query = query.Where(p => p.ProductSubcategoryID == subcategoryId);
            return await query.Take(10).ToListAsync(token);
        }

        public async Task<Domain.Entities.Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking()
           .FirstOrDefaultAsync(p => p.ProductID == id, cancellationToken);
        }
    }
}