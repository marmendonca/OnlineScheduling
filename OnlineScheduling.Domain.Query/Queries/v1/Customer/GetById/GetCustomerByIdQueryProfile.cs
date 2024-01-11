using AutoMapper;

namespace OnlineScheduling.Domain.Query.Queries.v1.Customer.GetById;

public sealed class GetCustomerByIdQueryProfile : Profile
{
    public GetCustomerByIdQueryProfile()
    {
        CreateMap<Entities.Customer, GetCustomerByIdQueryResponse>();
    }
}