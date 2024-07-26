namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IOrdersRepository
{
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Order> GetByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Guid> CreateAsync(Order order, CancellationToken cancellationToken = default);
    Task<Guid> UpdateAsync(Order order, CancellationToken cancellationToken = default);
    Task<Guid> DeleteAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Guid> AddDetailAsync(OrderDetails detail, CancellationToken cancellationToken = default);
};