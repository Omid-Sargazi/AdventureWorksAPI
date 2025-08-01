using AdventureWorks.Application.DTOs;
using AutoMapper;

namespace AdventureWorks.Application.Common.Mappings
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<(int CustomerId, int FullName, decimal TotalSales), TopCustomerDto>()
            .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.TotalSales, opt => opt.MapFrom(src => src.TotalSales));
        }
    }
}