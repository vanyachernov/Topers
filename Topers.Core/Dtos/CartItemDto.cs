namespace Topers.Core.Dtos;

public record CartItemResponseDto(
    Guid Id,
    Guid CartId,
    Guid GoodId,
    int Quantity,
    decimal Price
);

public record CartItemRequestDto(
    Guid CartId,
    Guid GoodId,
    int Quantity,
    decimal Price
);