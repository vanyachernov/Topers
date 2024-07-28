namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface ICartsRepository
{
    Task<Cart> GetById(Guid cartId, CancellationToken cancellationToken = default);
    Task<Cart> GetByCustomerId(Guid customerId, CancellationToken cancellationToken = default);
    Task<Guid> CreateAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<Guid> DeleteAsync(Guid cartId, CancellationToken cancellationToken = default);
    Task<Guid> AddDetailAsync(CartItems cartDetails, CancellationToken cancellationToken = default);
};
