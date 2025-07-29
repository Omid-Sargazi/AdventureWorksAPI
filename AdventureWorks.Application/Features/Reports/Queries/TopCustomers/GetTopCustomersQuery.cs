using AdventureWorks.Application.DTOs;
using MediatR;

namespace AdventureWorks.Application.Features.Reports.Queries.TopCustomers
{
    public record GetTopCustomersQuery(int count):IRequest<List<TopCustomerDto>>;
}