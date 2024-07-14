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
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address != null ? new AddressResponseDto(
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

        CreateMap<GoodScopeEntity, GoodScope>();
        CreateMap<GoodScope, GoodScopeEntity>();

        CreateMap<GoodEntity, Good>()
            .ForMember(dest => dest.Scopes, opt => opt.MapFrom(src => src.Scopes != null ? src.Scopes : new List<GoodScopeEntity>()));
        CreateMap<Good, GoodEntity>()
            .ForMember(dest => dest.Scopes, opt => opt.MapFrom(src => src.Scopes != null ? src.Scopes : new List<GoodScope>()));

        CreateMap<GoodScope, GoodScopeResponseDto>()
            .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ImageName));

        CreateMap<Good, GoodResponseDto>()
            .ForMember(dest => dest.Scopes, opt => opt.MapFrom(src => src.Scopes != null ? src.Scopes : new List<GoodScope>()));

        CreateMap<Good, GoodResponseDto>()
            .ForMember(dest => dest.Scopes, opt => opt.MapFrom(src =>
                src.Scopes != null
                    ? src.Scopes.Select(scope => new GoodScopeResponseDto(
                        scope.Id,
                        scope.GoodId,
                        scope.Litre,
                        scope.Price,
                        scope.ImageName
                    )).ToList()
                    : new List<GoodScopeResponseDto>()));
        
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();

        CreateMap<Customer, CustomerEntity>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<CustomerEntity, Customer>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<AddressEntity, Address>();
    }
}