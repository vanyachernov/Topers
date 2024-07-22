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

    public async Task<Guid> CreateAsync(Order order)
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

    public async Task<Guid> DeleteAsync(Guid orderId)
    {
        await _context.Orders
            .Where(o => o.Id == orderId)
            .ExecuteDeleteAsync();

        return orderId;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        var orderEntity = await _context.Orders
            .AsNoTracking()
            .ToListAsync();
        
        var orderEntitiesDto = _mapper.Map<List<Order>>(orderEntity);

        return orderEntitiesDto;
    }

    public async Task<Order> GetByIdAsync(Guid orderId)
    {
        var orderEntity = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == orderId);

        var orderEntityDto = _mapper.Map<Order>(orderEntity);

        return orderEntityDto;
    }

    public async Task<Guid> UpdateAsync(Order order)
    {
        await _context.Orders
            .Where(o => o.Id == order.Id)
            .ExecuteUpdateAsync(oUpdate => oUpdate
                .SetProperty(o => o.CustomerId, order.CustomerId));
        
        return order.Id;
    }
}