using Microsoft.AspNetCore.Http;

namespace Topers.Core.Dtos;

public record GoodResponseDto(
    Guid Id,
    string Name = "",
    string Description = "",
    string ImageName = "",
    IFormFile? Image = null
);

public record GoodRequestDto(
    Guid CategoryId,
    string Name = "",
    string Description = "",
    string ImageName = "",
    IFormFile? Image = null
);