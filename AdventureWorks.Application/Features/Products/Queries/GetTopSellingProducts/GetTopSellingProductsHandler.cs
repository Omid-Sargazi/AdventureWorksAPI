using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts
{
    public class GetTopSellingProductsHandler : IRequestHandler<GetTopSellingProductsQuery, List<TopProductDto>>
    {
        private readonly IReportingRepository _repository;
        public GetTopSellingProductsHandler(IReportingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TopProductDto>> Handle(GetTopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTopSellingProductsAsync(request.TopCount, cancellationToken);
        }
    }
}