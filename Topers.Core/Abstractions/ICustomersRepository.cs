namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface ICustomersRepository
{
    Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<Guid> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
}