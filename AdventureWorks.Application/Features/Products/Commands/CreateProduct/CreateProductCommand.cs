using MediatR;

namespace AdventureWorks.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(string Name,string ProductNumber,decimal ListPrice):IRequest<int>;
}