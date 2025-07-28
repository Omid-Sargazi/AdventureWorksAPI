using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Repository.Product
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly AdventureWorksDbContext _context;
        public ReportingRepository(AdventureWorksDbContext context)
        {
            _context = context;
        }
        public async Task<List<TopProductDto>> GetTopSellingProductsAsync(int topCount, CancellationToken cancellationToken)
        {
            var query = from detail in _context.SalesOrderDetails
                        group detail by detail.ProductID into g
                        join p in _context.Products on g.Key equals p.ProductID
                        orderby g.Sum(x => x.OrderQty) descending
                        select new TopProductDto
                        {
                            ProductID = g.Key,
                            Name = p.Name,
                            TotalQuantitySold = g.Sum(x => x.OrderQty),
                            TotalSales = g.Sum(x => x.LineTotal)
                        };

            return await query.Take(topCount).ToListAsync(cancellationToken);
        }
    }
}