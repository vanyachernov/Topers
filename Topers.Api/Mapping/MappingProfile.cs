using AutoMapper;
using Topers.Core.Dtos;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<AddressEntity, AddressResponseDto>();
        CreateMap<Address, AddressResponseDto>();

        CreateMap<Customer, CustomerResponseDto>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address != null ? new AddressResponseDto (
                src.Address.Id,
                src.Id,
                src.Address.Street,
                src.Address.City,
                src.Address.State,
                src.Address.PostalCode,
                src.Address.Country
            ) : null));

        CreateMap<CustomerRequestDto, Customer>();

        CreateMap<CategoryEntity, Category>();
        CreateMap<Category, CategoryEntity>();
        CreateMap<GoodEntity, Good>();
        CreateMap<Good, GoodEntity>();

        CreateMap<Customer, CustomerEntity>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<CustomerEntity, Customer>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<AddressEntity, Address>();
    }
}