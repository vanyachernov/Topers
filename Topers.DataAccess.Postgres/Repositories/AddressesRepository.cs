using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class AddressesRepository : IAddressesRepository
{
    private readonly TopersDbContext _context;

    public AddressesRepository(TopersDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Address address)
    {
        var addressEntity = new AddressEntity
        {
            Id = Guid.NewGuid(),
            CustomerId = address.CustomerId,
            Street = address.Street,
            City = address.City,
            State = address.State,
            PostalCode = address.PostalCode,
            Country = address.Country
        };

        await _context.Addresses.AddAsync(addressEntity);
        await _context.SaveChangesAsync();

        return addressEntity.Id;
    }
}