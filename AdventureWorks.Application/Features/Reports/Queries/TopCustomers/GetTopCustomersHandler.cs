using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Reports.Queries.TopCustomers
{
    public class GetTopCustomersHandler : IRequestHandler<GetTopCustomersQuery, List<TopCustomerDto>>
    {
        private readonly IReportingRepository _repository;
        public GetTopCustomersHandler(IReportingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<TopCustomerDto>> Handle(GetTopCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetTopCustomersAsync(request.count, cancellationToken);
            return result;
        }
    }
}