using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Topers.Core.Dtos;

public record GoodScopeResponseDto(
    Guid Id = default,
    Guid GoodId = default,
    int Litre = default,
    decimal Price = default,
    string? ImageName = ""
);

public record GoodScopeRequestDto(
    [Required] int Litre,
    [Required] decimal Price,
    string? ImageName = "",
    IFormFile? ImageFile = null
);