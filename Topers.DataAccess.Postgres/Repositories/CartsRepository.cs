using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class CartsRepository : ICartsRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public CartsRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> AddDetailAsync(
        CartItems cartDetails,
        CancellationToken cancellationToken = default
    )
    {
        var cartItemEntity = new CartItemEntity
        {
            Id = Guid.NewGuid(),
            CartId = cartDetails.CartId,
            GoodId = cartDetails.GoodId,
            Quantity = cartDetails.Quantity,
            Price = cartDetails.Price
        };

        await _context.CartDetails.AddAsync(cartItemEntity);
        await _context.SaveChangesAsync();

        return cartItemEntity.Id;
    }

    public async Task<Guid> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        var cartEntity = new CartEntity
        {
            Id = Guid.NewGuid(),
            CustomerId = cart.CustomerId,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        await _context.Cart.AddAsync(cartEntity);
        await _context.SaveChangesAsync();

        return cartEntity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid cartId, CancellationToken cancellationToken = default)
    {
        await _context.Cart.Where(c => c.Id == cartId).ExecuteDeleteAsync();

        return cartId;
    }

    public async Task<Cart> GetByCustomerId(
        Guid customerId,
        CancellationToken cancellationToken = default
    )
    {
        var cartEntity = await _context
            .Cart.Where(c => c.CustomerId == customerId)
            .AsNoTracking()
            .ToListAsync();

        var cart = _mapper.Map<Cart>(cartEntity);

        return cart;
    }

    public async Task<Cart> GetById(Guid cartId, CancellationToken cancellationToken = default)
    {
        var cartEntity = await _context
            .Cart.Where(c => c.Id == cartId)
            .AsNoTracking()
            .ToListAsync();

        var cart = _mapper.Map<Cart>(cartEntity);

        return cart;
    }
}
