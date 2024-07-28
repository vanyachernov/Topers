namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface ICartsService
{
    Task<CartResponseDto> GetCartById(Guid cartId, CancellationToken cancellationToken = default);
    Task<CartResponseDto> GetCartByCustomerId(Guid customerId, CancellationToken cancellationToken = default);
    Task<CartResponseDto> CreateCartAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<Guid> DeleteCartAsync(Guid cartId, CancellationToken cancellationToken = default);
    Task<Guid> AddGoodToCartAsync(CartItems cartDetails, GoodScope good, CancellationToken cancellationToken = default);
};