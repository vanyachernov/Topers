namespace Topers.Core.Abstractions;

using Topers.Core.Dtos;
using Topers.Core.Models;

public interface ICustomersService
{
    Task<List<CustomerResponseDto>> GetAllCustomersAsync();
    Task<CustomerResponseDto> GetCustomerByIdAsync(Guid customerId);
    Task<Guid> CreateCustomerAsync(Customer customer);
};