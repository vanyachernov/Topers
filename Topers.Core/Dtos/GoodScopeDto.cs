namespace Topers.Core.Dtos;

public record GoodScopeResponseDto(
    Guid Id,
    Guid GoodId,
    int Litre,
    decimal Price
);

public record GoodScopeRequestDto(
    Guid GoodId,
    int Litre,
    decimal Price
);