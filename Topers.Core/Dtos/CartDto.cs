namespace Topers.Core.Dtos;

public record CartResponseDto(
    Guid Id,
    Guid CustomerId,
    DateTime CreatedDate,
    DateTime UpdatedDate,
    List<CartItemResponseDto>? OrderDetails = null
);

public record CartRequestDto(
    Guid CustomerId
);
