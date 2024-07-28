using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class GoodsService : IGoodsService
{
    private readonly IGoodsRepository _goodsRepository;
    private readonly IMapper _mapper;

    public GoodsService(IGoodsRepository goodsRepository, IMapper mapper)
    {
        _goodsRepository = goodsRepository;
        _mapper = mapper;
    }

    public async Task<GoodResponseDto> CreateGoodAsync(
        Good good,
        CancellationToken cancellationToken = default
    )
    {
        var newGoodIdentifier = await _goodsRepository.CreateAsync(good, cancellationToken);

        var newGood = new GoodResponseDto(newGoodIdentifier, good.Name, good.Description, null);

        return newGood;
    }

    public async Task<Guid> DeleteGoodAsync(
        Guid goodId,
        CancellationToken cancellationToken = default
    )
    {
        return await _goodsRepository.DeleteAsync(goodId, cancellationToken);
    }

    public async Task<List<GoodResponseDto>> GetAllGoodsAsync(
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<List<GoodResponseDto>>(
            await _goodsRepository.GetAllAsync(cancellationToken)
        );
    }

    public async Task<GoodResponseDto> GetGoodByIdAsync(
        Guid goodId,
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<GoodResponseDto>(
            await _goodsRepository.GetByIdAsync(goodId, cancellationToken)
        );
    }

    public async Task<Guid> UpdateGoodAsync(
        Good good,
        CancellationToken cancellationToken = default
    )
    {
        return await _goodsRepository.UpdateAsync(good, cancellationToken);
    }

    public async Task<Guid> AddGoodScopeAsync(
        GoodScope scope,
        CancellationToken cancellationToken = default
    )
    {
        return await _goodsRepository.AddScopeAsync(scope, cancellationToken);
    }

    public async Task<Guid> UpdateGoodScopeAsync(
        GoodScope scope,
        CancellationToken cancellationToken = default
    )
    {
        return await _goodsRepository.UpdateScopeAsync(scope, cancellationToken);
    }

    public async Task<bool> IsGoodScopeExistsAsync(
        Guid goodId,
        int litre,
        CancellationToken cancellationToken = default
    )
    {
        var existingScope = await _goodsRepository.GetScopeAsync(goodId, litre, cancellationToken);

        return existingScope != null;
    }
}
