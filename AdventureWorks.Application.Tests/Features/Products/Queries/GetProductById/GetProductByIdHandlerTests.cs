using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Features.Products.Queries.GetProductById;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using FluentAssertions;
using Moq;

namespace AdventureWorks.Application.Tests.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly GetProductByIdHandler _handler;
        public GetProductByIdHandlerTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _handler = new GetProductByIdHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ExistingId_ShouldReturnProductDto()
        {
            var product = new Product
            {
                ProductID = 1,
                Name = "Test Product",
                ProductNumber = "PN22",
                ListPrice = 50,
            };

            _mockRepo.Setup(x => x.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(product);

            var query = new GetProductByIdQuery(1);

            var result = await _handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.ProductID.Should().Be(1);
            result.Name.Should().Be("Test Product");
        }

        public async Task Handle_NonExistingId_ShouldThrowNotFoundException()
        {
            _mockRepo.Setup(x => x.GetByIdAsync(99, It.IsAny<CancellationToken>()))
                 .ReturnsAsync((Product?)null);

            var query = new GetProductByIdQuery(99);
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}