namespace Topers.Core.Dtos;

public record OrderDetailsResponseDto(
    Guid Id,
    Guid OrderId,
    Guid GoodId,
    int Quantity,
    decimal Price
);

public record OrderDetailsRequestDto(
    Guid OrderId,
    Guid GoodId,
    int Quantity,
    decimal Price
);