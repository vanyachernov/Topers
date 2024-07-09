namespace Topers.Core.Dtos;

public record AddressResponseDto(
    Guid Id,
    Guid CustomerId,
    string Street = "",
    string City = "",
    string State = "",
    string PostalCode = "",
    string Country = ""
);

public record AddressRequestDto(
    string Street = "",
    string City = "",
    string State = "",
    string PostalCode = "",
    string Country = ""
);