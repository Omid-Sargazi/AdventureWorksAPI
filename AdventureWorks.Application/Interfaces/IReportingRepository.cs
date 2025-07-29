using AdventureWorks.Application.DTOs;

namespace AdventureWorks.Application.Interfaces
{
    public interface IReportingRepository
    {
        Task<List<TopProductDto>> GetTopSellingProductsAsync(int topCount, CancellationToken cancellationToken);
        Task<List<TopCustomerDto>> GetTopCustomersAsync(int topCount, CancellationToken cancellationToken);

    }
}