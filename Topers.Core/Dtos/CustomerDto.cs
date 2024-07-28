using System.ComponentModel.DataAnnotations;

namespace Topers.Core.Dtos;

public record CustomerResponseDto(
    Guid Id,
    string Name = "",
    string Email = "",
    string Phone = "",
    AddressResponseDto? Address = null
);

public record CustomerRequestDto(
    string Name = "",
    string Email = "",
    string Phone = ""
);