using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public OrdersRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        var orderEntity = new OrderEntity
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CustomerId = order.CustomerId,
            TotalPrice = order.TotalPrice
        };

        await _context.Orders.AddAsync(orderEntity);
        await _context.SaveChangesAsync();

        return orderEntity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid orderId, CancellationToken cancellationToken = default)
    {
        await _context.Orders.Where(o => o.Id == orderId).ExecuteDeleteAsync();

        return orderId;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var orderEntities = await _context
            .Orders.Include(o => o.OrderDetails)
            .AsNoTracking()
            .ToListAsync();

        var orders = _mapper.Map<List<Order>>(orderEntities);

        return orders;
    }

    public async Task<Order> GetByIdAsync(
        Guid orderId,
        CancellationToken cancellationToken = default
    )
    {
        var orderEntity = await _context
            .Orders.Include(o => o.OrderDetails)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == orderId);

        var orderEntityDto = _mapper.Map<Order>(orderEntity);

        return orderEntityDto;
    }

    public async Task<Guid> UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context
            .Orders.Where(o => o.Id == order.Id)
            .ExecuteUpdateAsync(oUpdate =>
                oUpdate.SetProperty(o => o.CustomerId, order.CustomerId)
            );

        return order.Id;
    }

    public async Task<Guid> AddDetailAsync(
        OrderDetails detail,
        CancellationToken cancellationToken = default
    )
    {
        var orderDetailEntity = new OrderDetailsEntity
        {
            Id = Guid.NewGuid(),
            OrderId = detail.OrderId,
            GoodId = detail.GoodId,
            Quantity = detail.Quantity,
            Price = detail.Price
        };

        await _context.OrderDetails.AddAsync(orderDetailEntity);
        await _context.SaveChangesAsync();

        var orderEntity = await GetByIdAsync(orderDetailEntity.OrderId, cancellationToken);

        await _context
            .Orders.Where(o => o.Id == orderDetailEntity.OrderId)
            .ExecuteUpdateAsync(
                oUpdate =>
                    oUpdate.SetProperty(
                        o => o.TotalPrice,
                        orderEntity.TotalPrice
                            + (orderDetailEntity.Price * orderDetailEntity.Quantity)
                    ),
                cancellationToken
            );

        return orderDetailEntity.Id;
    }
}
