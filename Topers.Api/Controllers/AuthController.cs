using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Topers.Core.Dtos;
using Topers.Core.Models;

namespace Topers.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    public static User _user = new User();

    [HttpPost("register")]
    public ActionResult<User> Register([FromBody] UserDto request)
    {
        string passwordHash 
            = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        _user.Username = request.Username;
        _user.PasswordHash = passwordHash;

        return Ok(_user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login([FromBody] UserDto request)
    {
        if (_user.Username != request.Username)
        {
            return BadRequest("User not found!");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, _user.PasswordHash))
        {
            return BadRequest("Wrong Password!");
        }

        return Ok(_user);
    }
}