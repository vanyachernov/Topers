using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IMapper _mapper;

    public OrdersService(
        IOrdersRepository ordersRepository,
        IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponseDto> CreateOrderAsync(Order order)
    {
        var newOrderIdentifier = await _ordersRepository.CreateAsync(order);

        var newOrder = new OrderResponseDto
        (
            newOrderIdentifier,
            order.Date,
            order.Customer.Id,
            order.TotalPrice
        );

        return newOrder;
    }

    public async Task<Guid> DeleteOrderAsync(Guid orderId)
    {
        return await _ordersRepository.DeleteAsync(orderId);
    }

    public async Task<List<OrderResponseDto>> GetAllOrdersAsync()
    {
        return _mapper.Map<List<OrderResponseDto>>(await _ordersRepository.GetAllAsync());
    }

    public async Task<OrderResponseDto> GetOrderByIdAsync(Guid orderId)
    {
        return _mapper.Map<OrderResponseDto>(await _ordersRepository.GetByIdAsync(orderId));
    }

    public async Task<Guid> UpdateOrderAsync(Order order)
    {
        return await _ordersRepository.UpdateAsync(order);
    }
}