using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class CartsService : ICartsService
{
    private readonly ICartsRepository _cartsRepository;
    private readonly IGoodsRepository _goodsRepository;
    private readonly IMapper _mapper;

    public CartsService(ICartsRepository cartsRepository, IGoodsRepository goodsRepository, IMapper mapper)
    {
        _cartsRepository = cartsRepository;
        _goodsRepository = goodsRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddGoodToCartAsync(
        CartItems cartDetails,
        GoodScope good,
        CancellationToken cancellationToken = default
    )
    {
        var goodScope = await _goodsRepository.GetScopeAsync(cartDetails.GoodId, good.Litre);

        var newCartItemsEntity = new CartItems(
            Guid.Empty,
            cartDetails.CartId,
            goodScope.GoodId,
            cartDetails.Quantity,
            goodScope.Price
        );

        return await _cartsRepository.AddDetailAsync(newCartItemsEntity, cancellationToken);
    }

    public async Task<CartResponseDto> CreateCartAsync(
        Cart cart,
        CancellationToken cancellationToken = default
    )
    {
        var newCartIdentifier = await _cartsRepository.CreateAsync(cart, cancellationToken);

        var newCart = new CartResponseDto(
            newCartIdentifier,
            cart.CustomerId,
            cart.CreatedDate,
            cart.UpdatedDate
        );

        return newCart;
    }

    public async Task<Guid> DeleteCartAsync(
        Guid cartId,
        CancellationToken cancellationToken = default
    )
    {
        return await _cartsRepository.DeleteAsync(cartId);
    }

    public async Task<CartResponseDto> GetCartByCustomerId(
        Guid customerId,
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<CartResponseDto>(
            await _cartsRepository.GetByCustomerId(customerId, cancellationToken)
        );
    }

    public async Task<CartResponseDto> GetCartById(
        Guid cartId,
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<CartResponseDto>(
            await _cartsRepository.GetById(cartId, cancellationToken)
        );
    }
}
