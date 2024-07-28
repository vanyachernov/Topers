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

    public async Task<CustomerResponseDto> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        var newCustomerIdentifier = await _customersRepository.CreateAsync(customer);

        var newCustomer = new CustomerResponseDto
        (
            newCustomerIdentifier,
            customer.Name,
            customer.Email,
            customer.Phone
        );

        return newCustomer;
    }

    public async Task<List<CustomerResponseDto>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
    {
        return _mapper.Map<List<CustomerResponseDto>>(await _customersRepository.GetAllAsync());
    }

    public async Task<CustomerResponseDto> GetCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return _mapper.Map<CustomerResponseDto>(await _customersRepository.GetByIdAsync(customerId));
    }
}