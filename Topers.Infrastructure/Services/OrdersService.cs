using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IGoodsRepository _goodsRepository;
    private readonly IMapper _mapper;

    public OrdersService(
        IOrdersRepository ordersRepository,
        IGoodsRepository goodsRepository,
        IMapper mapper)
    {
        _ordersRepository = ordersRepository;
        _goodsRepository = goodsRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponseDto> CreateOrderAsync(Order order)
    {
        var newOrderIdentifier = await _ordersRepository.CreateAsync(order);

        var newOrder = new OrderResponseDto
        (
            newOrderIdentifier,
            order.Date,
            order.CustomerId,
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

    public async Task<Guid> AddGoodToOrderAsync(OrderDetails detail, GoodScope good)
    {
        var goodScope = await _goodsRepository.GetScopeAsync(detail.GoodId, good.Litre);

        var newGoodDetailEntity = new OrderDetails
        (
            detail.OrderId,
            goodScope.Id,
            detail.Quantity,
            goodScope.Price
        );

        return await _ordersRepository.AddDetailAsync(newGoodDetailEntity);
    }
}