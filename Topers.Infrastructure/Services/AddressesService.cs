using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class AddressesService : IAddressesService
{
    private readonly IAddressesRepository _addressesRepository;
    private readonly IMapper _mapper;

    public AddressesService(IAddressesRepository addressesRepository, IMapper mapper)
    {
        _addressesRepository = addressesRepository;
        _mapper = mapper;
    }

    public async Task<AddressResponseDto> AddAddressToCustomerAsync(Address address)
    {
        var addressEntity = await _addressesRepository.CreateAsync(address);

        return _mapper.Map<AddressResponseDto>(addressEntity);
    }
}