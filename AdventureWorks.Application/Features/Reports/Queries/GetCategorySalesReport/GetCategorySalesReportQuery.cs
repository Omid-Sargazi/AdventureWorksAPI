using AdventureWorks.Application.DTOs;
using MediatR;

namespace AdventureWorks.Application.Features.Reports.Queries.GetCategorySalesReport
{
    public record GetCategorySalesReportQuery(): IRequest<List<CategorySalesDto>>;
}