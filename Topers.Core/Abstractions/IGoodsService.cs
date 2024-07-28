namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface IGoodsService
{
    Task<GoodResponseDto> CreateGoodAsync(Good good, CancellationToken cancellationToken = default);
    Task<List<GoodResponseDto>> GetAllGoodsAsync(CancellationToken cancellationToken = default);
    Task<GoodResponseDto> GetGoodByIdAsync(Guid goodId, CancellationToken cancellationToken = default);
    Task<Guid> UpdateGoodAsync(Good good, CancellationToken cancellationToken = default);
    Task<Guid> DeleteGoodAsync(Guid goodId, CancellationToken cancellationToken = default);
    Task<Guid> AddGoodScopeAsync(GoodScope scope, CancellationToken cancellationToken = default);
    Task<Guid> UpdateGoodScopeAsync(GoodScope scope, CancellationToken cancellationToken = default);
    Task<bool> IsGoodScopeExistsAsync(Guid goodId, int litre, CancellationToken cancellationToken = default);
};