namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IUsersRepository
{
    Task Add(User user, CancellationToken cancellationToken = default);
    Task<User> GetByName(string username, CancellationToken cancellationToken = default);
};