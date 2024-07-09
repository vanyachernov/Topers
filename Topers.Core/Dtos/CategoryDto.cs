namespace Topers.Core.Dtos;

public record CategoryResponseDto(
    Guid Id,
    string Name = "",
    string? Description = ""
);

public record CategoryRequestDto(
    string Name = "",
    string Description = ""
);