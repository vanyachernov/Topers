namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IAddressesRepository
{
    Task<Guid> CreateAsync(Address address, CancellationToken cancellationToken = default);
};