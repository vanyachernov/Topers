namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface ICustomersRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(Guid customerId);
    Task<Guid> CreateAsync(Customer customer);
}