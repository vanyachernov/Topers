
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Topers.Core.Abstractions;
using Topers.Core.Models;
using Topers.DataAccess.Postgres.Entities;

namespace Topers.DataAccess.Postgres.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly TopersDbContext _context;
    private readonly IMapper _mapper;

    public UsersRepository(TopersDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Add(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            Username = user.Username,
            PasswordHash = user.PasswordHash,
            Email = user.Email
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByName(string username)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username) ?? throw new Exception();

        return _mapper.Map<User>(userEntity);
    }
}