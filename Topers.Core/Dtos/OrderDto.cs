namespace Topers.Core.Dtos;

public record OrderResponseDto(
    Guid Id,
    DateTime Date,
    Guid CustomerId,
    decimal TotalPrice
);

public record OrderRequestDto(
    DateTime Date,
    Guid CustomerId,
    decimal TotalPrice
);