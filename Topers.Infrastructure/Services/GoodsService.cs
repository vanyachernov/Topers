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

    public async Task<GoodResponseDto> CreateGoodAsync(Good good)
    {
        var newGoodIdentifier = await _goodsRepository.CreateAsync(good);

        var newGood = new GoodResponseDto
        (
            newGoodIdentifier,
            good.Name,
            good.Description,
            null
        );

        return newGood;
    }

    public async Task<Guid> DeleteGoodAsync(Guid goodId)
    {
        return await _goodsRepository.DeleteAsync(goodId);
    }

    public async Task<List<GoodResponseDto>> GetAllGoodsAsync()
    {
        return _mapper.Map<List<GoodResponseDto>>(await _goodsRepository.GetAllAsync());
    }

    public async Task<GoodResponseDto> GetGoodByIdAsync(Guid goodId)
    {
        return _mapper.Map<GoodResponseDto>(await _goodsRepository.GetByIdAsync(goodId));
    }

    public async Task<Guid> UpdateGoodAsync(Good good)
    {
        return await _goodsRepository.UpdateAsync(good);
    }

    public async Task<Guid> AddGoodScopeAsync(GoodScope scope)
    {
        return await _goodsRepository.AddScopeAsync(scope);
    }

    public async Task<Guid> UpdateGoodScopeAsync(GoodScope scope)
    {
        return await _goodsRepository.UpdateScopeAsync(scope);
    }

    public async Task<bool> IsGoodScopeExistsAsync(Guid goodId, int litre)
    {
        var existingScope = await _goodsRepository.GetScopeAsync(goodId, litre);

        return existingScope != null;
    }
}