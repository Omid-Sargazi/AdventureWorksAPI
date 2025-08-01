using FluentValidation;

namespace AdventureWorks.Application.Features.Reports.Queries.TopCustomers
{
    public class GetTopCustomersValidator : AbstractValidator<GetTopCustomersQuery>
    {
        public GetTopCustomersValidator()
        {
            RuleFor(x => x.count)
            .GreaterThan(0).WithMessage("Count must be greater than 0")
            .LessThanOrEqualTo(100).WithMessage("Max allowed is 100");
        }
    }
}