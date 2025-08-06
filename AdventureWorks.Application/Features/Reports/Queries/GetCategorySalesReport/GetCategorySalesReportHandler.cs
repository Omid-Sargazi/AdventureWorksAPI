using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Reports.Queries.GetCategorySalesReport
{
    public class GetCategorySalesReportHandler : IRequestHandler<GetCategorySalesReportQuery, List<CategorySalesDto>>
    {
        private readonly IReportingRepository _reporting;
        public GetCategorySalesReportHandler(IReportingRepository reporting)
        {
            _reporting = reporting;
        }
        public async Task<List<CategorySalesDto>> Handle(GetCategorySalesReportQuery request, CancellationToken cancellationToken)
        {
            return await _reporting.GetCategorySalesReportAsync(cancellationToken);
        }
    }
}