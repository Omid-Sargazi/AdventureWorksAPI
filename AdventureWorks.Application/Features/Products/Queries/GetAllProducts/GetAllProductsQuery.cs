using AdventureWorks.Application.DTOs;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? SubcategoryId { get; set; }
    }
}