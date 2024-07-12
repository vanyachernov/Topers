namespace Topers.Core.Dtos;

public record GoodResponseDto(
    Guid Id,
    string Name = "",
    string? Description = "",
    List<GoodScopeResponseDto>? Scopes = null
);

public record GoodRequestDto(
    Guid CategoryId,
    string Name = "",
    string Description = ""
);