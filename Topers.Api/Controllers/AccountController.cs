using Microsoft.AspNetCore.Mvc;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;


namespace Topers.Api.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(IUsersService userService) : ControllerBase
{
    private readonly IUsersService _userService = userService;
    
    [HttpPost("register")]
    public async Task<IResult> Register([FromBody] RegisterUserRequestDto request)
    {
        await _userService.Register(request.Username, request.Email, request.Password);

        return Results.Ok();
    }

    [HttpPost("login")]
    public async Task<IResult> Login([FromBody] LoginUserRequestDto request)
    {
        var token = await _userService.Login(request.Username, request.Password);

        return Results.Ok(token);
    }
}