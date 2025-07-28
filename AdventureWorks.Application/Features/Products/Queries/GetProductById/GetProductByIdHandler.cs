using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (product == null)
                throw new NotFoundException($"Product with ID {request.id} not found.");

            return new ProductDto
            {
                ProductID = product.ProductID,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                ListPrice = product.ListPrice,
            };
        }
    }
}