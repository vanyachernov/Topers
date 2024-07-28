namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface IOrdersService
{
    Task<List<OrderResponseDto>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
    Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<OrderResponseDto> CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task<Guid> UpdateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task<Guid> DeleteOrderAsync(Guid orderId, CancellationToken cancellationToken = default);
    Task<Guid> AddGoodToOrderAsync(OrderDetails detail, GoodScope good, CancellationToken cancellationToken = default);
};