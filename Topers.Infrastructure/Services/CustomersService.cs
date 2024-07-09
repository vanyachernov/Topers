using AutoMapper;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class CustomersService : ICustomersService
{
    private readonly ICustomersRepository _customersRepository;
    private readonly IMapper _mapper;

    public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
    {
        _customersRepository = customersRepository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateCustomerAsync(Customer customer)
    {
        return await _customersRepository.CreateAsync(customer);
    }

    public async Task<List<CustomerResponseDto>> GetAllCustomersAsync()
    {
        return _mapper.Map<List<CustomerResponseDto>>(await _customersRepository.GetAllAsync());
    }

    public async Task<CustomerResponseDto> GetCustomerByIdAsync(Guid customerId)
    {
        return _mapper.Map<CustomerResponseDto>(await _customersRepository.GetByIdAsync(customerId));
    }
}