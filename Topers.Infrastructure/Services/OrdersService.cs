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
        IMapper mapper
    )
    {
        _ordersRepository = ordersRepository;
        _goodsRepository = goodsRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponseDto> CreateOrderAsync(
        Order order,
        CancellationToken cancellationToken = default
    )
    {
        var newOrderIdentifier = await _ordersRepository.CreateAsync(order, cancellationToken);

        var newOrder = new OrderResponseDto(
            newOrderIdentifier,
            order.Date,
            order.CustomerId,
            order.TotalPrice
        );

        return newOrder;
    }

    public async Task<Guid> DeleteOrderAsync(
        Guid orderId,
        CancellationToken cancellationToken = default
    )
    {
        return await _ordersRepository.DeleteAsync(orderId, cancellationToken);
    }

    public async Task<List<OrderResponseDto>> GetAllOrdersAsync(
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<List<OrderResponseDto>>(await _ordersRepository.GetAllAsync());
    }

    public async Task<OrderResponseDto> GetOrderByIdAsync(
        Guid orderId,
        CancellationToken cancellationToken = default
    )
    {
        return _mapper.Map<OrderResponseDto>(
            await _ordersRepository.GetByIdAsync(orderId, cancellationToken)
        );
    }

    public async Task<Guid> UpdateOrderAsync(
        Order order,
        CancellationToken cancellationToken = default
    )
    {
        return await _ordersRepository.UpdateAsync(order);
    }

    public async Task<Guid> AddGoodToOrderAsync(
        OrderDetails detail,
        GoodScope good,
        CancellationToken cancellationToken = default
    )
    {
        var goodScope = await _goodsRepository.GetScopeAsync(detail.GoodId, good.Litre);

        var newGoodDetailEntity = new OrderDetails(
            Guid.Empty,
            detail.OrderId,
            goodScope.Id,
            detail.Quantity,
            goodScope.Price
        );

        return await _ordersRepository.AddDetailAsync(newGoodDetailEntity, cancellationToken);
    }
}
