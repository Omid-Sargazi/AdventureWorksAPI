using AdventureWorks.Application.DTOs;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts
{
    public record GetTopSellingProductsQuery(int TopCount=10) : IRequest<List<TopProductDto>>;
}