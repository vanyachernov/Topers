using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Infrastructure.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UsersService(
        IUsersRepository usersRepository, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(string username, string email, string password, CancellationToken cancellationToken = default)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var newUser = User.Create(Guid.NewGuid(), username, hashedPassword, email);

        await _usersRepository.Add(newUser);
    }

    public async Task<string> Login(string username, string password, CancellationToken cancellationToken = default)
    {
        var user = await _usersRepository.GetByName(username);

        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (!result)
        {
            throw new Exception("Failed to log in!");
        }

        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}