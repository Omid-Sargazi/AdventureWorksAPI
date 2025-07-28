using AdventureWorks.Application.DTOs;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int id) :IRequest<ProductDto>;
}