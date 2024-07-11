using System.ComponentModel.DataAnnotations;

namespace Topers.Core.Dtos;

public record LoginUserRequestDto(
    [Required] string Username = "",
    [Required] string Password = ""
);

public record RegisterUserRequestDto(
    [Required] string Username = "",
    [Required] string Email = "",
    [Required] string Password = ""
);