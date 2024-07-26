namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface ICustomersService
{
    Task<List<CustomerResponseDto>> GetAllCustomersAsync(CancellationToken cancellationToken = default);
    Task<CustomerResponseDto> GetCustomerByIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<CustomerResponseDto> CreateCustomerAsync(Customer customer, CancellationToken cancellationToken = default);
};