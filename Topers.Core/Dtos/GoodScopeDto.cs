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
    Guid GoodId,
    int Litre,
    decimal Price,
    IFormFile? Image = null
);