namespace Topers.Core.Abstractions;

public interface IUsersService
{
    Task Register(string username, string email, string password, CancellationToken cancellationToken = default);
    Task<string> Login(string username, string password, CancellationToken cancellationToken = default);
};