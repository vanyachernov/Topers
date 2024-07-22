namespace Topers.Core.Dtos;

public record OrderResponseDto(
    Guid Id,
    DateTime Date,
    Guid CustomerId,
    decimal TotalPrice,
    List<OrderDetailsResponseDto>? OrderDetails = null
);

public record OrderRequestDto(
    DateTime Date,
    Guid CustomerId,
    decimal TotalPrice
);

public record UpdateOrderRequestDto(
    Guid CustomerId
);

public record AddProductToOrderRequestDto(
    Guid GoodScopeId,
    int GoodQuantity,
    int GoodLitre
);