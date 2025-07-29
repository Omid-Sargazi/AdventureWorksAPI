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

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int topCount, CancellationToken cancellationToken)
        {
            var result = await _context.SalesOrderHeaders
            .Include(o => o.Customer)
            .ThenInclude(c => c.Person)
            .GroupBy(o => new
            {
                o.Customer.CustomerID,
                FullName = o.Customer.Person.FirstName + " " + o.Customer.Person.LastName,
            })
            .Select(g => new TopCustomerDto
            {
                CustomerID = g.Key.CustomerID,
                FullName = g.Key.FullName,
                TotalSales = g.Sum(x => x.TotalDue)
            })
            .OrderByDescending(g => g.TotalSales)
            .Take(topCount)
            .ToListAsync();

            return result;
        }

        public async Task<List<TopProductDto>> GetTopSellingProductsAsync(int topCount, CancellationToken cancellationToken)
        {
            var rawData = await _context.SalesOrderDetails
            .Include(d => d.Product)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

            var result = rawData.GroupBy(d => new { d.ProductID, d.Product.Name })
            .Select(g => new TopProductDto
            {
                ProductID = g.Key.ProductID,
                Name = g.Key.Name,
                TotalQuantitySold = g.Sum(x => x.OrderQty),
                TotalSales = g.Sum(x => x.LineTotal)
            })
            .OrderByDescending(x => x.TotalQuantitySold)
            .Take(topCount)
            .ToList();

            return result;
        }
    }
}