using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.FilterProductsAsync(
                request.Name,
                request.MinPrice,
                request.MaxPrice,
                request.SubcategoryId,
                cancellationToken
            );

            return products.Select(p => new ProductDto
            {
                ProductID = p.ProductID,
                Name = p.Name,
                ListPrice = p.ListPrice,
            }).ToList();
        }
    }
}