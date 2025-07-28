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

        public async Task<Domain.Entities.Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking()
           .FirstOrDefaultAsync(p => p.ProductID == id, cancellationToken);
        }
    }
}