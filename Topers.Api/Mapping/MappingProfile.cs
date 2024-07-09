using AutoMapper;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryEntity, Category>();
        CreateMap<Category, CategoryEntity>();
        CreateMap<GoodEntity, Good>();
        CreateMap<Good, GoodEntity>();
    }
}