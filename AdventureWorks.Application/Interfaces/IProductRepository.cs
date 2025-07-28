using AdventureWorks.Domain.Entities;

namespace AdventureWorks.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(Product product, CancellationToken cancellationToken);
    }
}