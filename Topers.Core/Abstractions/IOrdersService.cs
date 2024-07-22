namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface IOrdersService
{
    Task<List<OrderResponseDto>> GetAllOrdersAsync();
    Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId);
    Task<OrderResponseDto> CreateOrderAsync(Order order);
    Task<Guid> UpdateOrderAsync(Order order);
    Task<Guid> DeleteOrderAsync(Guid orderId);
};