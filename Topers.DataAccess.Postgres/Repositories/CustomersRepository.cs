using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public CustomersRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        var customerEntity = new CustomerEntity
        {
            Id = Guid.NewGuid(),
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone
        };

        await _context.Customers.AddAsync(customerEntity);
        await _context.SaveChangesAsync();

        return customerEntity.Id;
    }

    public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var customerEntities = await _context.Customers
            .Include(c => c.Address)
            .AsNoTracking()
            .ToListAsync();

        var customerEntitiesDto = _mapper.Map<List<Customer>>(customerEntities);

        return customerEntitiesDto;
    }

    public async Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        var customerEntity = await _context.Customers
            .Include(c => c.Address)
            .FirstOrDefaultAsync(c => c.Id == customerId);

        var customerEntityDto = _mapper.Map<Customer>(customerEntity);

        return customerEntityDto;
    }
}