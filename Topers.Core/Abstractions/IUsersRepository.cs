namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByName(string username);
};