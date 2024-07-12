namespace Topers.Core.Abstractions;

public interface IUsersService
{
    Task Register(string username, string email, string password);
    Task<string> Login(string username, string password);
};