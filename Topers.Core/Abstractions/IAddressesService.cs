namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface IAddressesService
{
    Task<AddressResponseDto> AddAddressToCustomerAsync(Address address);
};