using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repo;

        public CreateProductHandler(IProductRepository repository)
        {
            _repo = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                ProductNumber = request.ProductNumber,
                ListPrice = request.ListPrice,
            };

            await _repo.AddAsync(product, cancellationToken);
            return product.ProductID;
        }
    }
}