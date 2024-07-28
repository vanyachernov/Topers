using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class AddressesService : IAddressesService
{
    private readonly IAddressesRepository _addressesRepository;

    public AddressesService(IAddressesRepository addressesRepository)
    {
        _addressesRepository = addressesRepository;
    }

    public async Task<AddressResponseDto> AddAddressToCustomerAsync(Address address, CancellationToken cancellationToken = default)
    {
        var addressEntityIdentifier = await _addressesRepository.CreateAsync(address);

        var newAddressEntity = new AddressResponseDto
        (
            addressEntityIdentifier,
            address.CustomerId,
            address.Street,
            address.City,
            address.State,
            address.PostalCode,
            address.Country
        );

        return newAddressEntity;
    }
}