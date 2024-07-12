namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface IGoodsService
{
    Task<GoodResponseDto> CreateGoodAsync(Good good);
    Task<List<GoodResponseDto>> GetAllGoodsAsync();
    Task<GoodResponseDto> GetGoodByIdAsync(Guid goodId);
    Task<Guid> UpdateGoodAsync(Good good);
    Task<Guid> DeleteGoodAsync(Guid goodId);
    Task<Guid> AddGoodScopeAsync(GoodScope scope);
};