using AdventureWorks.Application.Common.Mappings;
using AdventureWorks.Application.DTOs;
using AdventureWorks.Application.Features.Reports.Queries.TopCustomers;
using AdventureWorks.Application.Interfaces;
using AutoMapper;
using Moq;

namespace AdventureWorks.Application.Tests.Features.Reports.Queries
{
    public class GetTopCustomersHandlerTests
    {
        private readonly Mock<IReportingRepository> _mockRepository;
        private readonly IMapper _mapper;
        public GetTopCustomersHandlerTests()
        {
            _mockRepository = new Mock<IReportingRepository>();

            var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ReportProfile>();
        });

            _mapper = configuration.CreateMapper();
        }


        public async Task Handle_ReturnsExpectedTopCustomers()
        {
            var expected = new List<TopCustomerDto>
        {
            new TopCustomerDto { CustomerID = 1, FullName = "Ali Ahmadi", TotalSales = 1000 },
            new TopCustomerDto { CustomerID = 2, FullName = "Zahra Akbari", TotalSales = 900 }
        };

        _mockRepository.Setup(r => r.GetTopCustomersAsync(2, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        var handler = new GetTopCustomersHandler(_mockRepository.Object);
        var query = new GetTopCustomersQuery(2);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Ali Ahmadi", result[0].FullName);
        }


    }
}