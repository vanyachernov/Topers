namespace Topers.Core.Abstractions;

using Topers.Core.Models;

public interface IJwtProvider
{
    string GenerateToken(User user);
};