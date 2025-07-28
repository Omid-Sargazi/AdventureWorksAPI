using System.Runtime.InteropServices.Marshalling;
using AdventureWorks.Application.Features.Products.Commands.CreateProduct;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using FluentAssertions;
using Moq;

namespace AdventureWorks.Application.Tests.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly CreateProductHandler _handler;
        public CreateProductHandlerTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _handler = new CreateProductHandler(_mockRepo.Object);
        }


        [Fact]
        public async Task Handle_ValidCommand_ShouldAddProductAndReturnId()
        {
            var command = new CreateProductCommand("Test", "PN123", 99.99m);
            _mockRepo.Setup(x => x.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
            .Callback<Product, CancellationToken>((p, ct) => p.ProductID = 42)
            .Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().Be(42);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()));
        }
    }
}