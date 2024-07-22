namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IOrdersRepository
{
    Task<List<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(Guid orderId);
    Task<Guid> CreateAsync(Order order);
    Task<Guid> UpdateAsync(Order order);
    Task<Guid> DeleteAsync(Guid orderId);
};