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
    Guid CustomerId,
    string Street = "",
    string City = "",
    string State = "",
    string PostalCode = "",
    string Country = ""
);