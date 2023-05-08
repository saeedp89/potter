using AutoMapper;
using Potter.Domain.Entities;

namespace Potter.Application;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>()
            .ForMember(destinationMember => destinationMember.CreatedAt,
                mem => mem.Ignore())
            .ForMember(d => d.Id, s => s.Ignore())
            .ForMember(d => d.DeletedAt, s => s.Ignore()).ForMember(d => d.IsDeleted, s => s.Ignore())
            .ForMember(d => d.UpdatedAt,
                s => s.Ignore());
        CreateMap<Customer, CustomerDto>();
    }
}