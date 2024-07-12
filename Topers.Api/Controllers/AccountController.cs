using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Topers.Core.Abstractions;
using Topers.Core.Dtos;
using Topers.Infrastructure.Features;


namespace Topers.Api.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(
    IUsersService userService,
    IOptions<CookiesOptions> options) : ControllerBase
{
    private readonly IUsersService _userService = userService;
    private readonly CookiesOptions _cookieOptions = options.Value;
    
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

        HttpContext.Response.Cookies.Append(_cookieOptions.Name, token);

        return Results.Ok(token);
    }
}