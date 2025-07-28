using AdventureWorks.Application.DTOs;
using AdventureWorks.Domain.Entities;

namespace AdventureWorks.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
        Task<List<Product>> FilterProductsAsync(string? name, decimal? minPrice, decimal? maxPrice, int? subcategoryId, CancellationToken token);
       
    }
}