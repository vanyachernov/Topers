using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Topers.Core.Dtos;

public record GoodScopeResponseDto(
    Guid Id,
    Guid GoodId,
    int Litre,
    decimal Price,
    string? ImageName = "",
    IFormFile? Image = null
);

public record GoodScopeRequestDto(
    [Required] int Litre,
    [Required] decimal Price,
    string? ImageName = "",
    IFormFile? Image = null
);